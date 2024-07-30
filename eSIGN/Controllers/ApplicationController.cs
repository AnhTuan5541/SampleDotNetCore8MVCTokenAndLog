using Microsoft.AspNetCore.Mvc;

namespace eSIGN.Controllers
{
    public class ApplicationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
