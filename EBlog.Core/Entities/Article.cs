using EBlog.Core.Enums;
using EBlog.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlog.Core.Entities
{
    public class Article : IBaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        //Implement
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? PassivedAt { get; set; }
        public Status Status { get; set; }

        //Navigation
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }

        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }

        public virtual List<Comment> Comments { get; set; }
        public virtual List<Like> Likes { get; set; }
    }
}
