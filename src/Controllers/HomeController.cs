using Blog.HelpingModels.ViewModels;
using Blog.IRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IArticleRepository _articleRepo;

        public HomeController(ILogger<HomeController> logger, IArticleRepository articleRepo)
        {
            _logger = logger;
            _articleRepo = articleRepo;
        }

        public async Task<IActionResult> Index()
        {
            var articles = await _articleRepo.GetAllArticlesSorted();
            return View(articles);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}