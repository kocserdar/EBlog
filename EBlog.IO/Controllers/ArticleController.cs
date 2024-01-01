using EBlog.Core.Entities;
using EBlog.Service.Models.DTOs.Article;
using EBlog.Service.Services.ArticleServices;
using EBlog.Service.Services.GenreServices;
using EBlog.Service.Utilities.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EBlog.IO.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleServices _articleServices;
        private readonly IGenreServices _genreServices;
        private readonly IUnitOfWorks _unitOfWorks;

        public ArticleController(IArticleServices articleServices, IGenreServices genreServices, IUnitOfWorks unitOfWorks)
        {
            _articleServices = articleServices;
            _genreServices = genreServices;
            _unitOfWorks = unitOfWorks;
        }

        public async Task<IActionResult> Index()
        {
            var articles = await _articleServices.GetArticles();
            return View(articles);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {

            var getGenreVMs = await _genreServices.GetAllGenres();
            CreateArticleDTO articleDTO = new CreateArticleDTO();
            articleDTO.Genres = getGenreVMs;
            articleDTO.AppUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(articleDTO);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(CreateArticleDTO model)
        {
            if (ModelState.IsValid)
            {
                await _articleServices.Create(model);
                return  RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> LetRead(int id)
        {
            var article = await _articleServices.GetArticleDetail(id);
            return View(article);
        }

    }
}
