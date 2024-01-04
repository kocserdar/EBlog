using EBlog.Service.Models.VMs.Article;
using EBlog.Service.Models.VMs.Genre;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlog.Service.Models.DTOs.Article
{
    public class CreateArticleDTO
    {
        [Required(ErrorMessage = "Title can not be empty")]
        public string Title { get; set; }

        [Required(ErrorMessage ="Content can not be empty")]
        public string Content { get; set; }
        
        public int GenreId { get; set; }
        
        public List<GetGenreVM>? Genres { get; set; }

        public string AppUserId { get; set; }



    }
}
