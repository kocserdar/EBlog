using EBlog.Core.Entities;
using EBlog.Core.Enums;
using EBlog.Repo.Interfaces;
using EBlog.Service.Models.DTOs.AppUser;
using EBlog.Service.Models.VMs.AppUser;
using EBlog.Service.Utilities.UnitOfWorks;
using Microsoft.AspNetCore.Http;
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
        private readonly RoleManager<IdentityRole> _rolemanager;
        private readonly IPasswordHasher<AppUser> _passwordHasher;


        public AppUserService(UserManager<AppUser> userManager, IUnitOfWorks unitOfWorks, RoleManager<IdentityRole> rolemanager, IPasswordHasher<AppUser> passwordHasher, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _unitOfWorks = unitOfWorks;
            _rolemanager = rolemanager;
            _passwordHasher = passwordHasher;
            _signInManager = signInManager;
        }

        public async Task<UpdateProfileDTO> GetById(string id)
        {
            var user = await _unitOfWorks.AppUserRepo.GetDefault(x => x.Id == id);
            var model = _unitOfWorks.Mapper.Map<UpdateProfileDTO>(user);
            return model;
        }

        public async Task<SignInResult> Login(LoginDTO model)
        {
            var user = await _unitOfWorks.AppUserRepo.GetDefault(x => x.UserName == model.UserName);

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

        public async Task<IdentityResult> UpdateUser(UpdateProfileDTO model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            user.Status = Status.Updated;
            user.UpdatedAt = DateTime.Now;
            user.Email = model.UserName;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.UserName = model.UserName;
            user.PhoneNumber = model.PhoneNumber;
            user.ImagePath = model.ImagePath;
            user.PasswordHash = _passwordHasher.HashPassword(user, model.Password);
            var result = await _userManager.UpdateAsync(user);
            return result;

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





        //public async Task<AppUser> GetAllUserInfo(string userId)
        //{
        //    /*EBlog.Core.Helpers.FullName.GetFullName(x.AppUser.FirstName,x.AppUser.LastName),*/
        //    var user = await _appUserRepo.GetFilteredFirstOrDefault(
        //        select: x => new ProfilePageVM
        //        {
        //            FirstName = x.FirstName,
        //            LastName = x.LastName,
        //            UserName = x.UserName,
        //            ImagePath = x.ImagePath,
        //            FullName = EBlog.Core.Helpers.FullName.GetFullName(x.FirstName, x.LastName),
        //            PhoneNumber = x.PhoneNumber,
        //            Articles = x.Articles.Where(x => x.AppUserId == userId)
        //                                            .Select(x => new Models.VMs.Article.GetArticleVM
        //                                            {
        //                                                Content = x.Content,
        //                                                CreateDate = x.CreatedAt,
        //                                                Title = x.Title,
        //                                                Id = x.Id
        //                                            }
        //                                            .ToList(),
        //             Comments = 
        //        }
        //        );
        //}
    }
}
