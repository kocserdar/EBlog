using EBlog.Core.Entities;
using EBlog.IO.Models;
using EBlog.Service.Models.VMs.Home;
using EBlog.Service.Services.HomeServices;
using EBlog.Service.Utilities.UnitOfWorks;
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
        private readonly IHomeServices _homeServices;
        private readonly IUnitOfWorks _unitOfWorks;


        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, IHomeServices homeServices)
        {
            _logger = logger;
            _userManager = userManager;
            _homeServices = homeServices;
        }

        public async Task<IActionResult> Index(int page = 1, int genreId = 999, int filter = 0)
        {
            if (User.Identity.IsAuthenticated)
            {
                var a = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
                ViewData["UserName"] = a.FirstName + " " + a.LastName;
            }

            return View(await _homeServices.GetAll(page, genreId, filter));
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
