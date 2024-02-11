using EBlog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlog.Repo.Interfaces
{
    public interface IGenreRepo:IBaseRepo<Genre>
    {
        Task<List<Genre>> Search(string query);
    }
}
