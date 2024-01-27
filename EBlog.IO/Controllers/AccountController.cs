using Microsoft.AspNetCore.Mvc;

namespace EBlog.IO.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
