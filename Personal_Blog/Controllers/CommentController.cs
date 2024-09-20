using Microsoft.AspNetCore.Mvc;

namespace Personal_Blog.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
