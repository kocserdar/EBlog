using EBlog.Core.Enums;
using EBlog.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlog.Core.Entities
{
    public class Like : IBaseEntity
    {
        public int Id { get; set; }

        //Implement
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? PassivedAt { get; set; }
        public Status Status { get; set; }

        //Navigation
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }

        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }
    }
}
