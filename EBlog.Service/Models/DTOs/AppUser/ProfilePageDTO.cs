using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlog.Service.Models.DTOs.AppUser
{
    public class ProfilePageDTO
    {
        public string AppUserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ImagePath { get; set; }
        public string? UserName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? FullName { get; set; }
        public bool IsMe { get; set; }

        public virtual List<Core.Entities.Article> Articles { get; set; }
        public virtual List<Core.Entities.Comment> Comments { get; set; }
        public virtual List<Core.Entities.Like> Likes { get; set; }
    }
}
