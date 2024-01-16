using EBlog.Service.Models.DTOs.Comment;
using EBlog.Service.Models.VMs.Comment;
using EBlog.Service.Models.VMs.Like;
using EBlog.Service.Services.ArticleServices;
using EBlog.Service.Services.CommentServices;
using EBlog.Service.Utilities.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EBlog.IO.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentServices _commentServices;
        private readonly IArticleServices _articleServices;
        private readonly IUnitOfWorks _unitOfWorks;

        public CommentController(ICommentServices commentServices, IUnitOfWorks unitOfWorks, IArticleServices articleServices)
        {
            _commentServices = commentServices;
            _unitOfWorks = unitOfWorks;
            _articleServices = articleServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create(string AppUserId, int ArticleId, string usercommenttext)
        {
            CreateCommentDTO commentDTO = new CreateCommentDTO();
            commentDTO.AppUserId = AppUserId;
            commentDTO.ArticleId = ArticleId;
            commentDTO.Text = usercommenttext;
            await _commentServices.CreateComment(commentDTO);

            return RedirectToAction("Read", "Article", new { id = ArticleId });
        }

    }
}
