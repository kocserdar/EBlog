using AutoMapper;
using EBlog.Core.Entities;
using EBlog.Service.Models.DTOs.AppUser;
using EBlog.Service.Models.VMs.AppUser;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlog.Service.Mapping
{
    public class Mapping : Profile
    {
        public Mapping() 
        {
            CreateMap<AppUser, RegisterDTO>().ReverseMap();
            CreateMap<AppUser, LoginDTO>().ReverseMap();
            CreateMap<AppUser, UpdateProfileDTO>().ReverseMap();

            CreateMap<AppUser, AppUserListVM>().ReverseMap();

            CreateMap<IdentityRole, CreateRoleDTO>().ReverseMap();
            CreateMap<IdentityRole, CreateRoleVM>().ReverseMap();


        }
    }
}
