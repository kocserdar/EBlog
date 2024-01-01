using EBlog.Core.Entities;
using EBlog.Repo.Interfaces;
using EBlog.Service.Models.DTOs.Genre;
using EBlog.Service.Models.VMs.Genre;
using EBlog.Service.Utilities.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlog.Service.Services.GenreServices
{
    public class GenreServices : IGenreServices
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IGenreRepo _genreRepo;

        public GenreServices(IUnitOfWorks unitOfWorks, IGenreRepo genreRepo)
        {
            _unitOfWorks = unitOfWorks;
            _genreRepo = genreRepo;
        }

        public async Task CreateGenre(CreateGenreDTO model)
        {
            if (model != null)
            {
                var genre = _unitOfWorks.Mapper.Map<Genre>(model);
                genre.Status = Core.Enums.Status.Active;
                genre.CreatedAt = DateTime.Now;
                await _genreRepo.Create(genre);

            }
        }

        public async Task DeleteGenre(int id)
        {
            var genre = await _genreRepo.GetById(id);
            if (genre != null) 
            {
                genre.Status = Core.Enums.Status.Passive;
                genre.PassivedAt = DateTime.Now;
                _genreRepo.Delete(genre);
            }
        }

        public async Task<List<GetGenreVM>> GetAllGenres()
        {
            var genres = await _genreRepo.GetFilteredList(
                select: x => new GetGenreVM
                {
                    Id = x.Id,
                    Name = x.Name,
                },
                where: x => x.Status != Core.Enums.Status.Passive,
                orderBy: x => x.OrderBy(x => x.Id)
                );
            return genres;
        }

        public async Task<GetGenreVM> GetById(int id)
        {
            var genre = await _genreRepo.GetById(id);
            return _unitOfWorks.Mapper.Map<GetGenreVM>(genre);
        }

        public void UpdateGenre(GetGenreVM model)
        {
            var genre = _unitOfWorks.Mapper.Map<Genre>(model);
            genre.Status = Core.Enums.Status.Updated;
            genre.UpdatedAt = DateTime.Now;
            _genreRepo.Update(genre);
        }
    }
}
