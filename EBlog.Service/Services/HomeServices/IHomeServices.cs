using EBlog.Service.Models.VMs.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlog.Service.Services.HomeServices
{
    public interface IHomeServices
    {
        Task<HomePageVM> GetAll(int page, int genreId, int filter);

    }
}
