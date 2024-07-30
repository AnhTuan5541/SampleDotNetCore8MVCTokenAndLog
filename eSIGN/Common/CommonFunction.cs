using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.AspNetCore.Http;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data;
using System.Data.Common;

namespace eSIGN.Common
{
    public class CommonFunction
    {
        public static readonly string SUCCESS = "SUCCESS";
        public static readonly string FAIL = "FAIL";
        public static readonly string ERROR = "ERROR";
        public static List<Dictionary<string, object>> GetDataFromProcedure(SqlDataReader reader) 
        {
            List<Dictionary<string, object>> dictionary = new List<Dictionary<string, object>>();
            while (reader.Read())
            {
                var row = new Dictionary<string, object>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    var columnName = reader.GetName(i);
                    var columnValue = reader.GetValue(i);
                    row.Add(columnName, columnValue);
                }
                dictionary.Add(row);
            }
            return dictionary;
        }

        public static string GenerateToken(string empID)
        {
            //Create token

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Amkor_Technology_Vietnam_is_the_best_company_in_Viet_Nam"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "eSign",
                audience: "https://localhost:44309/",
                claims: new[] { new Claim(ClaimTypes.Name, empID) },
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
            //End create token
        }

        public static void LogInfo(string DefaultConnection, string idCard, string info, string typeLog, string function)
        {
            using var connection = new SqlConnection(DefaultConnection);
            using var command = new SqlCommand("AddLogInfo", connection) { CommandType = CommandType.StoredProcedure };

            // Thêm các tham số cho stored procedure (nếu cần)
            command.Parameters.AddWithValue("@idCard", idCard);
            command.Parameters.AddWithValue("@info", info);
            command.Parameters.AddWithValue("@typeLog", typeLog);
            command.Parameters.AddWithValue("@function", function);

            connection.Open();
            var reader = command.ExecuteReader();
        }
    }
}
