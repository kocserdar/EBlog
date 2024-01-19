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

        public List<EBlog.Core.Entities.AppUser>? appUsers { get; set; }

        public List<EBlog.Core.Entities.Comment>? Comments { get; set; }

        public List<EBlog.Core.Entities.Like>? Likes { get; set; }

        public List<EBlog.Core.Entities.Article>? Articles { get; set; }

        public List<EBlog.Core.Entities.Genre>? Genres { get; set; }

    }
}
