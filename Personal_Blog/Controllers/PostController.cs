using Microsoft.AspNetCore.Mvc;
using Personal_Blog.Models.Schema;
using Personal_Blog.Repository.Interfaces;

namespace Personal_Blog.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostRepository _repo;
        public PostController(IPostRepository repo)
        {
            _repo = repo;
            
        }
        public IActionResult Index()
        {
            var data = _repo.GetAll();
            return View(data);
            
        }

        public IActionResult Create()
        { 
            return View();
        }

        [HttpPost]
        public IActionResult Create(Post post)
        {
            _repo.Create(post);
            return RedirectToAction("Index");

        }

        public IActionResult Edit(int id)
        {
            var data = _repo.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Post post)
        { 
            _repo.Update(post);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var data = _repo.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Delete(Post post)
        {
            _repo.Delete(post);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        { 
            var data = _repo.GetById(id);
            return View(data);
        }
    }
}
