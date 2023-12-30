using EBlog.Service.Models.DTOs.AppUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlog.Service.Services.AppUserServices
{
    public interface IAppUserService
    {
        Task<IdentityResult> Register(RegisterDTO model);
        Task<SignInResult> Login(LoginDTO model);
        Task LogOut();
        Task<UpdateProfileDTO> GetById(string id);
        Task UpdateUser(UpdateProfileDTO model);

        Task<IdentityResult> CreateRole(CreateRoleDTO model);

    }
}
