using Microsoft.AspNetCore.Mvc;

namespace EBlog.IO.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //public IActionResult CreateRoles()
        //{

        //}
    }
}
