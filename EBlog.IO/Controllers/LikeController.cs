using EBlog.Service.Models.DTOs.Like;
using EBlog.Service.Models.VMs.Article;
using EBlog.Service.Services.ArticleServices;
using EBlog.Service.Services.LikeServices;
using EBlog.Service.Utilities.UnitOfWorks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EBlog.IO.Controllers
{
    public class LikeController : Controller
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly ILikeServices _likeServices;
        private readonly IArticleServices _articleServices;

        public LikeController(IUnitOfWorks unitOfWorks, ILikeServices likeServices, IArticleServices articleServices)
        {
            _unitOfWorks = unitOfWorks;
            _likeServices = likeServices;
            _articleServices = articleServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create(GetArticleDetailVM model)
        {
                CreateLikeDTO likeDTO = new CreateLikeDTO()
                {
                    AppUserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    ArticleId = model.Id
                };

                await _likeServices.CreateLike(likeDTO);

                return RedirectToAction("Read","Article",new {id = model.Id});
        }
    }
}
