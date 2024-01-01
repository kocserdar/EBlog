using EBlog.Core.Entities;
using EBlog.Service.Models.DTOs.Genre;
using EBlog.Service.Models.VMs.Genre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlog.Service.Services.GenreServices
{
    public interface IGenreServices
    {
        Task CreateGenre(CreateGenreDTO model);
        
        void UpdateGenre(GetGenreVM model);
        
        Task DeleteGenre(int id);

        Task<GetGenreVM> GetById(int id);
        
        Task<List<GetGenreVM>> GetAllGenres();

    }
}
