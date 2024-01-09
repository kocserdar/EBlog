﻿using EBlog.Core.Entities;
using EBlog.Repo.Interfaces;
using EBlog.Service.Models.DTOs.Article;
using EBlog.Service.Models.VMs.Article;
using EBlog.Service.Models.VMs.Comment;
using EBlog.Service.Utilities.UnitOfWorks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using EBlog.Core.Helpers;
using System.Security.Cryptography.X509Certificates;

namespace EBlog.Service.Services.ArticleServices
{
    public class ArticleServices : IArticleServices
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IArticleRepo _articleRepo;

        public ArticleServices(IUnitOfWorks unitOfWorks, IArticleRepo articleRepo)
        {
            _unitOfWorks = unitOfWorks;
            _articleRepo = articleRepo;
        }

        public async Task Create(CreateArticleDTO model)
        {
            var article = _unitOfWorks.Mapper.Map<Article>(model);
            article.Status = Core.Enums.Status.Active;
            article.CreatedAt = DateTime.Now;
            await _articleRepo.Create(article);

        }

        public async Task Delete(int id)
        {
            var article = await _articleRepo.GetById(id);
            article.Status = Core.Enums.Status.Passive;
            article.PassivedAt = DateTime.Now;
            _articleRepo.Delete(article);
        }

        public async Task<GetArticleDetailVM> GetArticleDetail(int id)
        {
            var article = await _articleRepo.GetFilteredFirstOrDefault(
                select: x => new GetArticleDetailVM
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content,
                    AuthorFullName = x.AppUser.FirstName + " " + x.AppUser.LastName, //EBlog.Core.Helpers.FullName.GetFullName(x.AppUser.FirstName,x.AppUser.LastName),
                    CommentCount = x.Comments.Count, //.Where(x => x.Id == id).ToList()
                    LikeCount = x.Likes.Count,
                    CreateDate = x.CreatedAt,
                    GenreId = x.GenreId,
                    GenreName = x.Genre.Name,
                    LikeList = x.Likes.Where(x => x.ArticleId == id)
                                                    .Select(x => new Models.VMs.Like.GetLikeVM
                                                    {
                                                        Id = x.Id,
                                                        AppUserId = x.AppUser.Id,
                                                        ArticleId = x.ArticleId,
                                                        Status = x.Status
                                                    })
                                                    .Where(y => y.Status != Core.Enums.Status.Passive)
                                                    .ToList(),
                    CommentList = x.Comments.Where(x => x.ArticleId == id)
                                                    .OrderByDescending(x => x.CreatedAt)
                                                    .Select(x => new GetCommentVM
                                                    {
                                                        Id = x.Id,
                                                        Text = x.Text,
                                                        CreateDate = x.CreatedAt,
                                                        UserName = x.AppUser.UserName  //x.AppUser.UserName
                                                    }).ToList()

                },
                where: x => x.Id == id && x.Status != Core.Enums.Status.Passive,
                join: x => x.Include(x => x.AppUser).Include(x => x.Comments).Include(x => x.Likes).Include(x => x.Genre));
            return article;
        }

        public async Task<List<GetArticleVM>> GetArticles()
        {
            var articles = await _articleRepo.GetFilteredList(
                select: x => new GetArticleVM
                {
                    Id = x.Id,
                    Content = x.Content,
                    Title = x.Title,
                    CreateDate = x.CreatedAt,
                    GenreId = x.GenreId,
                    CommentCount = x.Comments.Count,
                    LikeCount = x.Likes.Count,
                    AuthorFullName = x.AppUser.FirstName + " " + x.AppUser.LastName,

                },
                where: x => x.Status != Core.Enums.Status.Passive,
                orderBy: x => x.OrderByDescending(x => x.CreatedAt),
                join: x => x.Include(x => x.AppUser).Include(x => x.Likes).Include(x => x.Comments));
            return articles;

        }

        public void Update(EditArticleDTO model)
        {
            if (model != null)
            {
                var article = _unitOfWorks.Mapper.Map<Article>(model);
                article.UpdatedAt = DateTime.Now;
                article.Status = Core.Enums.Status.Updated;
                _articleRepo.Update(article);
            }
        }

        public async Task<EditArticleDTO> GetArticle(int id)
        {
            var article = await _articleRepo.GetById(id);
            return _unitOfWorks.Mapper.Map<EditArticleDTO>(article);
        }
    }
}
