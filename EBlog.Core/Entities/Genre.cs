using EBlog.Core.Enums;
using EBlog.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlog.Core.Entities
{
    public class Genre : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Implement
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? PassivedAt { get; set; }
        public Status Status { get; set; }

        //Navigation
        public virtual List<Article> Articles { get; set; }
    }
}
