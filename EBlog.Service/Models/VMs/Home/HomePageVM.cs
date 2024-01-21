using EBlog.Service.Models.VMs.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlog.Service.Models.VMs.Home
{
    public class HomePageVM
    {
        public string? AppUserId { get; set; }
        public int FilterId { get; set; }
        public int Page { get; set; }
        public int GenreId { get; set; }
        public List<EBlog.Core.Entities.AppUser>? appUsers { get; set; }
        public List<GetArticleVM>? Articles { get; set; }
        public List<EBlog.Core.Entities.Genre>? Genres { get; set; }

    }
}
