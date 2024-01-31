using EBlog.Core.Entities;
using EBlog.Service.Models.DTOs.Article;
using EBlog.Service.Services.ArticleServices;
using EBlog.Service.Services.GenreServices;
using EBlog.Service.Utilities.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
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
        public async Task<IActionResult> Read(int id)
        {
            var article = await _articleServices.GetArticleDetail(id);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (User.Identity.IsAuthenticated)
            {
                article.IsLiked = article.LikeList.Where(x => x.ArticleId == id).Select(x => x.AppUserId).ToList().Contains(userId);
                article.IsMine = article.AppUserId == userId ? true : false;
            }

            return View(article);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _articleServices.Delete(id);
            //return RedirectToAction($"/articles/{id}");
            return RedirectToAction("Index","Article");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var article = await _articleServices.GetArticle(id);
            var getGenreVMs = await _genreServices.GetAllGenres();
            article.Genres = getGenreVMs;
            article.AppUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(article);
            //return RedirectToAction($"/articles/{id}");
            return RedirectToAction("Index", "Article");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditArticleDTO model)
        {
            if (ModelState.IsValid)
            {
                 _articleServices.Update(model);
                TempData["ArticleEditMessage"] = "Success";
            }
                var getGenreVMs = await _genreServices.GetAllGenres();
                model.Genres = getGenreVMs;
                return View(model);
        }

    }
}
