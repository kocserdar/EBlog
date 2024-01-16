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
    public interface IUnitOfWorks
    {
        IMapper Mapper { get; }
        IAppUserRepo AppUserRepo { get; }
        IArticleRepo ArticleRepo { get; }
        IGenreRepo GenreRepo { get; }
        ILikeRepo LikeRepo { get; }
        ICommentRepo CommentRepo { get; }

    }
}
