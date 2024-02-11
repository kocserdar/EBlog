using EBlog.Service.Models.VMs.Genre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlog.Service.Models.DTOs.Article
{
    public class EditArticleDTO
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int GenreId { get; set; }

        public DateTime CreatedAt { get; set; }

        public List<GetGenreVM>? Genres { get; set; }

        public string AppUserId { get; set; }
    }
}
