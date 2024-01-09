using EBlog.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlog.Service.Models.VMs.Like
{
    public class GetLikeVM
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public string AppUserId { get; set; }
        public int ArticleId { get; set; }
    }
}
