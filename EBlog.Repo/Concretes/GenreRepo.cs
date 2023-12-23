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
        public GenreRepo(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
