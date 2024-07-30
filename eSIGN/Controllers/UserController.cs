﻿using eSIGN.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eSIGN.Response;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Options;
using eSIGN.Common;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace eSIGN.Controllers
{
    public class UserController : Controller
    {
        private readonly ConnectionStrings _connection;
        public UserController(IOptions<ConnectionStrings> connection){_connection = connection.Value;}
        
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        [Authorize]
        public IActionResult GetAllUser()
        {
            string functionName = ControllerContext.ActionDescriptor.ControllerName + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name;
            string userid = User.FindFirstValue(ClaimTypes.Name);
            try
            {
                using var connection = new SqlConnection(_connection.DefaultConnection);
                using var command = new SqlCommand("GetAllUser", connection){CommandType = CommandType.StoredProcedure};

                // Thêm các tham số cho stored procedure (nếu cần)
                // command.Parameters.AddWithValue("@paramName", paramValue);

                connection.Open();
                var reader = command.ExecuteReader();

                List<Dictionary<string, object>> data = CommonFunction.GetDataFromProcedure(reader);

                CommonFunction.LogInfo(_connection.DefaultConnection, userid, "Get user success", CommonFunction.SUCCESS, functionName);
                var response = new CommonResponse<Dictionary<string, object>>
                {
                    StatusCode = CommonFunction.SUCCESS,
                    Message = "Get user success",
                    Data = data,
                    size = data.Count
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi (ví dụ: log lỗi, trả về phản hồi lỗi)
                CommonFunction.LogInfo(_connection.DefaultConnection, userid, ex.Message, CommonFunction.ERROR, functionName);
                var errorResponse = new CommonResponse<User>
                {
                    StatusCode = CommonFunction.ERROR,
                    Message = ex.Message,
                    Data = null,
                    size = 0
                };
                return StatusCode(500, errorResponse);
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetUserById(int id)
        {
            try
            {
                using var connection = new SqlConnection(_connection.DefaultConnection);
                using var command = new SqlCommand("GetUserById", connection) { CommandType = CommandType.StoredProcedure };

                // Thêm các tham số cho stored procedure (nếu cần)
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                var reader = command.ExecuteReader();

                List<Dictionary<string, object>> data = CommonFunction.GetDataFromProcedure(reader);

                var response = new CommonResponse<Dictionary<string, object>>
                {
                    StatusCode = "Success",
                    Message = "Get user by id success",
                    Data = data,
                    size = data.Count
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi (ví dụ: log lỗi, trả về phản hồi lỗi)
                var errorResponse = new CommonResponse<User>
                {
                    StatusCode = "Fail",
                    Message = ex.Message,
                    Data = null,
                    size = 0
                };
                return StatusCode(500, errorResponse);
            }
        }

    }
}
