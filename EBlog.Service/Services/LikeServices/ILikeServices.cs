using EBlog.Service.Models.DTOs.Like;
using EBlog.Service.Models.VMs.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlog.Service.Services.LikeServices
{
    public interface ILikeServices
    {
        Task CreateLike(CreateLikeDTO model);

        Task DeleteLike(int id);
    }
}
