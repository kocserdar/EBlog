using EBlog.Core.Entities;
using EBlog.Core.Enums;
using EBlog.Repo.Interfaces;
using EBlog.Service.Models.DTOs.AppUser;
using EBlog.Service.Utilities.UnitOfWorks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlog.Service.Services.AppUserServices
{
    public class AppUserService : IAppUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IAppUserRepo _appUserRepo;
        private readonly RoleManager<IdentityRole> _rolemanager;


        public AppUserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IUnitOfWorks unitOfWorks, IAppUserRepo appUserRepo, RoleManager<IdentityRole> rolemanager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _unitOfWorks = unitOfWorks;
            _appUserRepo = appUserRepo;
            _rolemanager = rolemanager;
        }

        public async Task<UpdateProfileDTO> GetById(string id)
        {
            var user = await _appUserRepo.GetDefault(x => x.Id == id);
            var model = _unitOfWorks.Mapper.Map<UpdateProfileDTO>(user);
            return model;
        }

        public async Task<SignInResult> Login(LoginDTO model)
        {
            var user = await _appUserRepo.GetDefault(x => x.UserName == model.UserName);

            if (user.Status == Status.Passive)
            {
                return SignInResult.Failed;
            }
            else
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                return result;
            }
        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> Register(RegisterDTO model)
        {
            var user = _unitOfWorks.Mapper.Map<AppUser>(model);
            user.Email = model.UserName;
            user.CreatedAt = DateTime.Now;


            var result = await _userManager.CreateAsync(user);
            await _userManager.AddToRoleAsync(user, "Normal");

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
            }
            return result;
        }

        public async Task UpdateUser(UpdateProfileDTO model)
        {
            if (model != null)
            {
                var user = _unitOfWorks.Mapper.Map<AppUser>(model);
                user.UpdatedAt = DateTime.Now;
                user.Email = model.UserName;
                user.Status = Status.Updated;
                //_appUserRepo.Update(user);
                //await _userManager.UpdateAsync(user);
                if (model.UserName != null)
                {
                    await _userManager.SetEmailAsync(user, model.UserName);
                    await _userManager.SetUserNameAsync(user, model.UserName);
                    await _signInManager.SignInAsync(user, false);
                }
                _appUserRepo.Update(user);
            }
            //if (model.Password != null)
            //{
            //    user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
            //    await _userManager.UpdateAsync(user);
            //}

        }



        public async Task<IdentityResult> CreateRole(CreateRoleDTO model)
        {
            if (model != null)
            {
                var user = _unitOfWorks.Mapper.Map<IdentityRole>(model);
                var result = await _rolemanager.CreateAsync(new IdentityRole(model.Name));

                if (result.Succeeded)
                {
                    return result;
                }
            }

            return IdentityResult.Failed();
        }
    }
}
