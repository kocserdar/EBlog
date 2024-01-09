using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlog.Service.Models.DTOs.Like
{
    public class CreateLikeDTO
    {
        public string AppUserId { get; set; }
        public int ArticleId { get; set; }
    }
}
