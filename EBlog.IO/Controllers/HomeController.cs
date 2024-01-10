using EBlog.Core.Entities;
using EBlog.IO.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace EBlog.IO.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _userManager;


        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            if(User.Identity.IsAuthenticated)
            {
                var a = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
                ViewData["UserName"] = a.FirstName + " " + a.LastName;
                return View();
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
