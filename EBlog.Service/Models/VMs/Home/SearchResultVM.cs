using EBlog.Service.Models.VMs.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlog.Service.Models.VMs.Home
{
    public class SearchResultVM
    {
        public List<EBlog.Core.Entities.Article>? Articles { get; set; }
       
        public List<EBlog.Core.Entities.AppUser>? Users { get; set; }

        public List<EBlog.Core.Entities.Genre>? Genres { get; set; }
    }
}
