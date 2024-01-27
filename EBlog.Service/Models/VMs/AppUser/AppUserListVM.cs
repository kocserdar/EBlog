using EBlog.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlog.Service.Models.VMs.AppUser
{
    public class AppUserListVM
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public Status Status { get; set; }
        public string RoleName { get; set; }
        public int ArticleCount { get; set; }

    }
}
