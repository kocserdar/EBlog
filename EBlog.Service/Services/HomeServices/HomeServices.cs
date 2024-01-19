using EBlog.Core.Entities;
using EBlog.Service.Models.VMs.Home;
using EBlog.Service.Utilities.UnitOfWorks;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EBlog.Service.Services.HomeServices
{
    public class HomeServices : IHomeServices
    {
        private readonly IUnitOfWorks _unitOfWorks;

        public HomeServices(IUnitOfWorks unitOfWorks)
        {
            _unitOfWorks = unitOfWorks;
        }

        public async Task<HomePageVM> GetAll()
        {
            List<Comment> comments = new List<Comment>();

            comments = await _unitOfWorks.CommentRepo.GetDefaults(x => x.Status != Core.Enums.Status.Passive);

            List<Genre> genres = new List<Genre>(); 

            genres = await _unitOfWorks.GenreRepo.GetDefaults(x => x.Status != Core.Enums.Status.Passive);

            List<Article> articles = new List<Article>();

            articles = await _unitOfWorks.ArticleRepo.GetDefaults(x => x.Status != Core.Enums.Status.Passive);

            HomePageVM pageVM = new HomePageVM()
            {
                AppUserId = "abc",
                 Comments = comments,
                 Articles = articles,
                  Genres = genres,
            };
            return pageVM;
        }
    }
}
