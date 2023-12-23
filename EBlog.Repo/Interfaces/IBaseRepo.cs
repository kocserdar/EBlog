using EBlog.Core.Interfaces;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EBlog.Repo.Interfaces
{
    public interface IBaseRepo<T> where T : IBaseEntity
    {
        Task Create(T entity);
        void Update(T entity);
        void Delete(T entity);

        Task<T> GetById(int id);
        Task<bool> Any(Expression<Func<T, bool>> expression);
        Task<T> GetDefault(Expression<Func<T, bool>> expression);
        Task<List<T>> GetDefaults(Expression<Func<T, bool>> expression);
        Task<TResult> GetFilteredFirstOrDefault<TResult>(
            Expression<Func<T, TResult>> select,
            Expression<Func<T, bool>> where = null,
            Func<IQueryable<T>, IIncludableQueryable<T, Object>> join = null
            );

        Task<List<TResult>> GetFilteredList<TResult>(
            Expression<Func<T, TResult>> select,
            Expression<Func<T, bool>> where = null,
            Func<IQueryable<T>, IQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, Object>> join = null
            );
    }
}
