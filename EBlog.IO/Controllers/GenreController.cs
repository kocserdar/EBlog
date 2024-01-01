using EBlog.Core.Entities;
using EBlog.Service.Models.DTOs.Genre;
using EBlog.Service.Models.VMs.Genre;
using EBlog.Service.Services.GenreServices;
using EBlog.Service.Utilities.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;

namespace EBlog.IO.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreServices _genreServices;

        public GenreController(IGenreServices genreServices, IUnitOfWorks unitOfWorks)
        {
            _genreServices = genreServices;
        }

        public async Task<IActionResult> Index()
        {
            var genres = await _genreServices.GetAllGenres();
            return View(genres);
        }

        [HttpGet]
        public IActionResult CreateGenre()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditGenre(int id)
        {
            var genre = await _genreServices.GetById(id);
            
            return View(genre);
        }

        [HttpPost]
        public IActionResult EditGenre(GetGenreVM model)
        {
            _genreServices.UpdateGenre(model);
            return RedirectToAction("Index");

        }


        [HttpPost]
        public async Task<IActionResult> CreateGenre(CreateGenreDTO model)
        {
            if (ModelState.IsValid)
            {
                await _genreServices.CreateGenre(model);
            }
            return RedirectToAction("Index","Genre");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteGenre(int id)
        {
           await _genreServices.DeleteGenre(id);
           return RedirectToAction("Index", "Genre");
        }


    }
}
