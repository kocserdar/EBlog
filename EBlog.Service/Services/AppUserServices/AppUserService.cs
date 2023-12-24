using EBlog.Core.Entities;
using EBlog.Repo.Interfaces;
using EBlog.Service.Models.DTOs.AppUser;
using EBlog.Service.Utilities.UnitOfWorks;
using Microsoft.AspNetCore.Identity;
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

        public AppUserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IUnitOfWorks unitOfWorks, IAppUserRepo appUserRepo)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _unitOfWorks = unitOfWorks;
            _appUserRepo = appUserRepo;
        }

        public async Task<UpdateProfileDTO> GetById(string id)
        {
            var user = await _appUserRepo.GetDefault(x => x.Id == id);
            var model = _unitOfWorks.Mapper.Map<UpdateProfileDTO>(user);
            return model;
        }

        public async Task<SignInResult> Login(LoginDTO model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password,false,false);
            return result;
        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> Register(RegisterDTO model)
        {
            var user = _unitOfWorks.Mapper.Map<AppUser>(model);

            var result = await _userManager.CreateAsync(user);

            if(result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
            }
            return result;
        }

        public async Task UpdateUser(UpdateProfileDTO model)
        {
            var user = _unitOfWorks.Mapper.Map<AppUser>(model);

            if(model != null)
            {
                _appUserRepo.Update(user);
            }
            if(model.Password != null)
            {
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
                await _userManager.UpdateAsync(user);
            }
            if(model.UserName != null)
            {
                await _userManager.SetEmailAsync(user, model.UserName);
                await _userManager.SetUserNameAsync(user, model.UserName);
                await _signInManager.SignInAsync(user, false);
            }
        }
    }
}
