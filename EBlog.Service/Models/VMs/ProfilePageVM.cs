using EBlog.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlog.Service.Models.VMs
{
    public class ProfilePageVM
    {
        public string Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ImagePath { get; set; }
        public string? Email { get; set;}
        public string? UserName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? FullName { get; set; }

        public virtual List<EBlog.Core.Entities.Article> Articles { get; set; }
        public virtual List<EBlog.Core.Entities.Comment> Comments { get; set; }
        public virtual List<Like> Likes { get; set; }
    }
}
