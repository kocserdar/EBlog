using EBlog.Core.Entities;
using EBlog.Core.Enums;
using EBlog.Repo.Interfaces;
using EBlog.Service.Models.DTOs.AppUser;
using EBlog.Service.Models.VMs.AppUser;
using EBlog.Service.Services.AppUserServices;
using EBlog.Service.Utilities.UnitOfWorks;
using Microsoft.AspNetCore.Hosting;
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
            if(id == null&& User.Identity.IsAuthenticated)
            {
                id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }

            ProfilePageVM user = await _appUserService.GetByIdProfilePage(id);

            if (user.Id == User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                user.IsMe = true;
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
                else 
                {
                    ModelState.AddModelError("", "E-mail address or password incorrect");
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
        public async Task<IActionResult> UpdateUser(string id)
        {
            var user = await _appUserService.GetById(id);

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(UpdateProfileDTO model)
        {
            if(model.Password is null || model.ConfirmPassword is null)
            {
                ModelState.AddModelError("", "Please enter your password, twice");
                return View(model);
            };

            var result = await _appUserService.UpdateUser(model);
            if (!result.Succeeded)
            {
                return RedirectToAction("UpdateUser", new { id = model.Id });
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UpdateRole()
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
                    return RedirectToAction("GetRoles", "User",model);
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var roles  = await _appUserService.GetRoles();
            //return View(roles);
            return View("GetRoles", roles);
        }


        [HttpGet]
        public async Task<IActionResult> MakeUserPassive(string id)
        {
            await _appUserService.MakeUserPassive(id);
            return RedirectToAction("Index");
        }
    }
}
