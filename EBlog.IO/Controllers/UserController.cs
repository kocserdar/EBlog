using EBlog.Core.Entities;
using EBlog.Core.Enums;
using EBlog.Repo.Interfaces;
using EBlog.Service.Models.DTOs.AppUser;
using EBlog.Service.Models.VMs.AppUser;
using EBlog.Service.Services.AppUserServices;
using EBlog.Service.Utilities.UnitOfWorks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Security.Claims;

namespace EBlog.IO.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IAppUserService _appUserService;

        public UserController(IUnitOfWorks unitOfWorks, IAppUserService appUserService)
        {
            _unitOfWorks = unitOfWorks;
            _appUserService = appUserService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _appUserService.GetAllUsers());
        }

        public async Task<IActionResult> ProfilePage(string id)
        {
            ProfilePageVM user = await _appUserService.GetByIdProfilePage(id);

            if (user.Id == User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                user.IsMe = true;
            }
            else
            {
                user.IsMe= false;
            }

            return View(user);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            if (ModelState.IsValid)
            {
                var result = await _appUserService.Register(model);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {

            HttpContext.Session.SetString("ReturnUrl", Request.Headers["Referer"].ToString());
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            var returnUrl = HttpContext.Session.GetString("ReturnUrl");

            if (ModelState.IsValid)
            {
                var result = await _appUserService.Login(model);
                if (result.Succeeded)
                {
                    return Redirect(returnUrl);
                }

                if (!result.Succeeded)
                {
                    return View("NotActiveUser");
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _appUserService.LogOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateUser()
        {
            var user = await _appUserService.GetById(User.FindFirstValue(ClaimTypes.NameIdentifier));

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(UpdateProfileDTO model)
        {
            await _appUserService.UpdateUser(model);
            //var user = await _appUserService.GetById(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleDTO model)
        {

            if (ModelState.IsValid)
            {
                var result = await _appUserService.CreateRole(model);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> MakeUserPassive(string id)
        {
            await _appUserService.MakeUserPassive(id);
            return RedirectToAction("Index");
        }

    }
}
