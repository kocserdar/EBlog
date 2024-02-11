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
    public class AppUserRepo : BaseRepo<AppUser>, IAppUserRepo
    {
        private readonly AppDbContext _appDbContext;
        public AppUserRepo(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
            _table = _appDbContext.Set<AppUser>();
        }

        public async Task<List<AppUser>> Search(string query)
        {
            return _appDbContext.AppUsers.Where(x => x.Status != Core.Enums.Status.Passive && x.Email.ToLower().Contains(query) || x.FirstName.ToLower().Contains(query) || x.LastName.ToLower().Contains(query)).ToList();
        }
    }
}
