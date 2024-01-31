using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlog.Service.Models.VMs.AppUser
{
    public class GetRolesVM
    {
        public List<IdentityRole> Roles { get; set; }
    }
}
