using AutoMapper;
using EBlog.Core.Entities;
using EBlog.Repo.Interfaces;
using EBlog.Service.Services.AppUserServices;
using EBlog.Service.Services.ArticleServices;
using EBlog.Service.Services.GenreServices;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlog.Service.Utilities.UnitOfWorks
{
    public class UnitOfWorks : IUnitOfWorks
    {
        public UnitOfWorks(IMapper mapper, IAppUserRepo appUserRepo, IArticleRepo articleRepo, IGenreRepo genreRepo, ILikeRepo likeRepo, ICommentRepo commentRepo)
        {
            Mapper = mapper;
            AppUserRepo = appUserRepo;
            ArticleRepo = articleRepo;
            GenreRepo = genreRepo;
            LikeRepo = likeRepo;
            CommentRepo = commentRepo;
        }

        public IMapper Mapper { get;}

        public IAppUserRepo AppUserRepo { get; }

        public IArticleRepo ArticleRepo { get; }

        public IGenreRepo GenreRepo { get; }

        public ILikeRepo LikeRepo { get; }

        public ICommentRepo CommentRepo { get; }

    }
}
