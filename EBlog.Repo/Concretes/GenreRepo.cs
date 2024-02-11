using EBlog.Core.Entities;
using EBlog.Repo.Contexts;
using EBlog.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlog.Repo.Concretes
{
    public class GenreRepo : BaseRepo<Genre>, IGenreRepo
    {
        private readonly AppDbContext _appDbContext;
        
        public GenreRepo(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
            _table = _appDbContext.Set<Genre>();
        }

        public async Task<List<Genre>> Search(string query)
        {
            return _appDbContext.Genres.Where(x => x.Status != Core.Enums.Status.Passive && x.Name.ToLower().Contains(query)).ToList();
        }
    }
}
