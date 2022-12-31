using Blog.Data;
using Blog.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    }
}
