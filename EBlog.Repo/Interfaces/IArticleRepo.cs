using EBlog.Core.Entities;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EBlog.Repo.Interfaces
{
    public interface IArticleRepo:IBaseRepo<Article>
    {
        Task<List<TResult>> GetArticlesListPaged<TResult>(
            Expression<Func<Article, TResult>> select,
            Expression<Func<Article, bool>> where = null,
            Func<IQueryable<Article>, IQueryable<Article>> orderBy = null,
            Func<IQueryable<Article>, IIncludableQueryable<Article, Object>> join = null,
            int skip = 0,
            int take = 10
            );
    }
}
