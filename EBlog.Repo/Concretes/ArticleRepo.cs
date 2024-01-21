using EBlog.Core.Entities;
using EBlog.Repo.Contexts;
using EBlog.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EBlog.Repo.Concretes
{
    public class ArticleRepo : BaseRepo<Article>, IArticleRepo
    {
        private readonly AppDbContext _appDbContext;

        public ArticleRepo(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
            _table = _appDbContext.Set<Article>();
        }

        //public Task<List<Article>> GetArticlesPaged(int pageNumber)
        //{

        //    throw new NotImplementedException();
        //}

        public async Task<List<TResult>> GetArticlesListPaged<TResult>(
            Expression<Func<Article, TResult>> select, 
            Expression<Func<Article, bool>> where = null, 
            Func<IQueryable<Article>, IQueryable<Article>> orderBy = null, 
            Func<IQueryable<Article>, IIncludableQueryable<Article, object>> join = null,
            int skip = 0,
            int take = 10)
        {
            IQueryable<Article> query = _table;
            if (join != null)
            {
                query = join(query);
            }
            if (where != null)
            {
                query = query.Where(where);
            }
            if (orderBy != null)
            {
                return await orderBy(query).Skip(skip).Take(take).Select(select).ToListAsync();
            }
            else
            {
                return await query.Select(select).ToListAsync();
            }
        }
    }
}
