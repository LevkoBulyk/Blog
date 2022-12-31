using Blog.Data.Enum;
using Blog.IRepositories;
using Blog.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Blog.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public AccountController(IUserRepository userRepository,
                                 SignInManager<AppUser> signInManager,
                                 UserManager<AppUser> userManager)
        {
            _userRepository = userRepository;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Register()
        {
            return View(new UserRegistration());
        }

       [HttpPost]
       public async Task<IActionResult> Register(UserRegistration userRegistration)
        {
            if (!ModelState.IsValid)
            {
                return View(userRegistration);
            }

            var user = await _userManager.FindByEmailAsync(userRegistration.Email);
            if (user != null) 
            {
                TempData["Error"] = "User with this email address is already registered";
                return View(userRegistration);
            }

            user = new AppUser() 
            {
                Email = userRegistration.Email,
                UserName = userRegistration.Name.IsNullOrEmpty()
                           ? userRegistration.Email.Substring(0, userRegistration.Email.IndexOf("@"))
                           : userRegistration.Name,
                PhotoUrl = userRegistration.PhotoUrl
            };

            var newUserResponce = await _userManager.CreateAsync(user, userRegistration.Password);

            if (newUserResponce.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Admin);
                return RedirectToAction("Index", "Home");
            }

            TempData["Error"] = newUserResponce.Errors.First().Description;
            return View(userRegistration);
        }
    }
}
