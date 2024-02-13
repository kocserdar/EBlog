using EBlog.Core.Entities;
using EBlog.Core.Helpers;
using EBlog.Service.Models.VMs.Article;
using EBlog.Service.Models.VMs.Home;
using EBlog.Service.Utilities.UnitOfWorks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
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

        public async Task<SearchResultVM> Search(string query)
        {
            SearchResultVM searchResultVM = new SearchResultVM();
            searchResultVM.Articles = await _unitOfWorks.ArticleRepo.Search(query);
            searchResultVM.Genres = await _unitOfWorks.GenreRepo.Search(query);
            searchResultVM.Users = await _unitOfWorks.AppUserRepo.Search(query);
            return searchResultVM;
        }


        public async Task<HomePageVM> GetAll(int page, int genreId, int filter)
        {

            int skip = Paging.PagingFunc(page).skip;
            int take = Paging.PagingFunc(page).take;

            List<Genre> genres = new List<Genre>();
            genres = await _unitOfWorks.GenreRepo.GetDefaults(x => x.Status != Core.Enums.Status.Passive);
            
            List<GetArticleVM> articles = new List<GetArticleVM>();

            //Genre Chosen
            if (genreId != 999)
            {
                switch (filter)
                {
                    case 0: //Most Liked
                        articles = await _unitOfWorks.ArticleRepo.GetArticlesListPaged(
                        select: x => new GetArticleVM
                        {
                            Id = x.Id,
                            UserId = x.AppUser.Id,
                            Content = x.Content,
                            Title = x.Title,
                            CreateDate = x.CreatedAt,
                            GenreId = x.GenreId,
                            GenreName = x.Genre.Name,
                            CommentCount = x.Comments.Where(x => x.Status != Core.Enums.Status.Passive).Count(),
                            LikeCount = x.Likes.Where(x => x.Status != Core.Enums.Status.Passive).Count(),
                            AuthorFullName = x.AppUser.FirstName + " " + x.AppUser.LastName,

                        },
                        where: x => x.Status != Core.Enums.Status.Passive && x.GenreId == genreId,
                        orderBy: x => x.OrderByDescending(x => x.Likes.Where(x => x.Status != Core.Enums.Status.Passive).Count()).Skip(skip).Take(take),
                        join: x => x.Include(x => x.AppUser).Include(x => x.Genre).Include(x => x.Likes).Include(x => x.Comments)
                        );
                        break;
                    case 1: // Most Comment
                        articles = await _unitOfWorks.ArticleRepo.GetArticlesListPaged(
                        select: x => new GetArticleVM
                        {
                            Id = x.Id,
                            UserId = x.AppUser.Id,
                            Content = x.Content,
                            Title = x.Title,
                            CreateDate = x.CreatedAt,
                            GenreId = x.GenreId,
                            GenreName = x.Genre.Name,
                            CommentCount = x.Comments.Where(x => x.Status != Core.Enums.Status.Passive).Count(),
                            LikeCount = x.Likes.Where(x => x.Status != Core.Enums.Status.Passive).Count(),
                            AuthorFullName = x.AppUser.FirstName + " " + x.AppUser.LastName,

                        },
                        where: x => x.Status != Core.Enums.Status.Passive && x.GenreId == genreId,
                        orderBy: x => x.OrderByDescending(x => x.Comments.Where(x => x.Status != Core.Enums.Status.Passive).Count()).Skip(skip).Take(take),
                        join: x => x.Include(x => x.AppUser).Include(x => x.Genre).Include(x => x.Likes).Include(x => x.Comments)
                        );
                        break;
                    case 2: //New
                        articles = await _unitOfWorks.ArticleRepo.GetArticlesListPaged(
                        select: x => new GetArticleVM
                        {
                            Id = x.Id,
                            UserId = x.AppUser.Id,
                            Content = x.Content,
                            Title = x.Title,
                            CreateDate = x.CreatedAt,
                            GenreId = x.GenreId,
                            GenreName = x.Genre.Name,
                            CommentCount = x.Comments.Where(x => x.Status != Core.Enums.Status.Passive).Count(),
                            LikeCount = x.Likes.Where(x => x.Status != Core.Enums.Status.Passive).Count(),
                            AuthorFullName = x.AppUser.FirstName + " " + x.AppUser.LastName,

                        },
                        where: x => x.Status != Core.Enums.Status.Passive && x.GenreId == genreId,
                        orderBy: x => x.OrderByDescending(x => x.CreatedAt).Skip(skip).Take(take),
                        join: x => x.Include(x => x.AppUser).Include(x => x.Genre).Include(x => x.Likes).Include(x => x.Comments)
                        );
                        break;
                }
            }
            else
            {
                switch (filter)
                {
                    case 0: //Most Liked
                        articles = await _unitOfWorks.ArticleRepo.GetArticlesListPaged(
                        select: x => new GetArticleVM
                        {
                            Id = x.Id,
                            UserId = x.AppUser.Id,
                            Content = x.Content,
                            Title = x.Title,
                            CreateDate = x.CreatedAt,
                            GenreId = x.GenreId,
                            GenreName = x.Genre.Name,
                            CommentCount = x.Comments.Where(x => x.Status != Core.Enums.Status.Passive).Count(),
                            LikeCount = x.Likes.Where(x => x.Status != Core.Enums.Status.Passive).Count(),
                            AuthorFullName = x.AppUser.FirstName + " " + x.AppUser.LastName,

                        },
                        where: x => x.Status != Core.Enums.Status.Passive,
                        orderBy: x => x.OrderByDescending(x => x.Likes.Where(x => x.Status != Core.Enums.Status.Passive).Count()).Skip(skip).Take(take),
                        join: x => x.Include(x => x.AppUser).Include(x => x.Genre).Include(x => x.Likes).Include(x => x.Comments)
                        );
                        break;
                    case 1: // Most Comment
                        articles = await _unitOfWorks.ArticleRepo.GetArticlesListPaged(
                        select: x => new GetArticleVM
                        {
                            Id = x.Id,
                            UserId = x.AppUser.Id,
                            Content = x.Content,
                            Title = x.Title,
                            CreateDate = x.CreatedAt,
                            GenreId = x.GenreId,
                            GenreName = x.Genre.Name,
                            CommentCount = x.Comments.Where(x => x.Status != Core.Enums.Status.Passive).Count(),
                            LikeCount = x.Likes.Where(x => x.Status != Core.Enums.Status.Passive).Count(),
                            AuthorFullName = x.AppUser.FirstName + " " + x.AppUser.LastName,

                        },
                        where: x => x.Status != Core.Enums.Status.Passive,
                        orderBy: x => x.OrderByDescending(x => x.Comments.Where(x => x.Status != Core.Enums.Status.Passive).Count()).Skip(skip).Take(take),

                        join: x => x.Include(x => x.AppUser).Include(x => x.Genre).Include(x => x.Likes).Include(x => x.Comments)
                        );
                        break;
                    case 2: //New
                        articles = await _unitOfWorks.ArticleRepo.GetArticlesListPaged(
                        select: x => new GetArticleVM
                        {
                            Id = x.Id,
                            UserId = x.AppUser.Id,
                            Content = x.Content,
                            Title = x.Title,
                            CreateDate = x.CreatedAt,
                            GenreId = x.GenreId,
                            GenreName = x.Genre.Name,
                            CommentCount = x.Comments.Where(x => x.Status != Core.Enums.Status.Passive).Count(),
                            LikeCount = x.Likes.Where(x => x.Status != Core.Enums.Status.Passive).Count(),
                            AuthorFullName = x.AppUser.FirstName + " " + x.AppUser.LastName,

                        },
                        where: x => x.Status != Core.Enums.Status.Passive,
                        orderBy: x => x.OrderByDescending(x => x.CreatedAt).Skip(skip).Take(take),
                        join: x => x.Include(x => x.AppUser).Include(x => x.Genre).Include(x => x.Likes).Include(x => x.Comments)
                        );
                        break;
                }
            }

            //Default
            if (genreId == 999 && filter == 0)
            {
                    articles = await _unitOfWorks.ArticleRepo.GetArticlesListPaged(
                    select: x => new GetArticleVM
                    {
                        Id = x.Id,
                        UserId = x.AppUser.Id,
                        Content = x.Content,
                        Title = x.Title,
                        CreateDate = x.CreatedAt,
                        GenreId = x.GenreId,
                        GenreName = x.Genre.Name,
                        CommentCount = x.Comments.Where(x => x.Status != Core.Enums.Status.Passive).Count(),
                        LikeCount = x.Likes.Where(x => x.Status != Core.Enums.Status.Passive).Count(),
                        AuthorFullName = x.AppUser.FirstName + " " + x.AppUser.LastName,

                    },
                    where: x => x.Status != Core.Enums.Status.Passive,
                    orderBy: x => x.OrderByDescending(x => x.Likes.Where(x => x.Status != Core.Enums.Status.Passive).Count()).Skip(skip).Take(take),
                    join: x => x.Include(x => x.AppUser).Include(x => x.Genre).Include(x => x.Likes).Include(x => x.Comments)
                    );
            }


            HomePageVM HomepageVM = new HomePageVM()
            {
                AppUserId = "abc",
                Articles = articles,
                Genres = genres,
                FilterId = filter,
                GenreId = genreId,
                Page = page
            };
            return HomepageVM;
        }
    }
}
