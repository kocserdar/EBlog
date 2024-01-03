using Microsoft.AspNetCore.Mvc;

namespace EBlog.IO.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
