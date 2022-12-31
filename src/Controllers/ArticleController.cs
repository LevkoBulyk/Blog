using Blog.IRepositories;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleRepository _articleRepo;

        public ArticleController(IArticleRepository articleRepo)
        {
            _articleRepo = articleRepo;
        }

        public async Task<IActionResult> Index()
        {
            var articles = await _articleRepo.GetAllArticlesSorted();

            return View(articles);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var article = await _articleRepo.GetArticleById(id);

            return View(article);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var article = await _articleRepo.GetArticleById(id);

            return View(article);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Article article)
        {
            article.LastEdition = DateTime.Now;
            _articleRepo.Update(article);
            return RedirectToAction("Index");
        }
    }
}
