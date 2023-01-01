using Blog.IRepositories;
using Blog.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleRepository _articleRepo;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserRepository _userRepository;

        public ArticleController(IArticleRepository articleRepo,
                                 UserManager<AppUser> userManager,
                                 IUserRepository userRepository)
        {
            _articleRepo = articleRepo;
            _userManager = userManager;
            _userRepository = userRepository;
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
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Create()
        {
            var userId = _userManager.GetUserId(User);

            var user = await _userRepository.GetUserById(userId);

            var article = new Article()
            {
                AuthorId = userId,
                Author = user
            };

            return View(article);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Article article)
        {
            if (article.Author == null)
            {
                var user = await _userRepository.GetUserById(article.AuthorId);
                article.Author = user;
            }

            if (!ModelState.IsValid)
            {
                return View(article);
            }

            article.LastEdition = DateTime.Now;
            _articleRepo.Create(article);

            return RedirectToAction("Index", "Home");
        }
    }
}
