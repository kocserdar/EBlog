using EBlog.Core.Enums;
using EBlog.Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlog.Core.Entities
{
    public class AppUser:IdentityUser, IBaseEntity
    {
        private string _ImagePath = "defaultuser_512px.png";

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ImagePath 
        {
            get { return _ImagePath; }
            set
            {
                if(value != null)
                {
                    _ImagePath = value;
                }
            } 
        }

        //Implement
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? PassivedAt { get; set; }
        public Status Status { get; set; } = Status.Active;

        //Navigation
        public virtual List<Article> Articles { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Like> Likes { get; set; }


    }
}
