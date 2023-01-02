using Blog.Data.Enum;
using Blog.HelpingModels.ViewModels;
using Blog.IRepositories;
using Blog.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Blog.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserRepository _userRepository;

        public AccountController(SignInManager<AppUser> signInManager,
                                 UserManager<AppUser> userManager,
                                 IUserRepository userRepository)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userRepository = userRepository;
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

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserLoggingIn userLoggingIn)
        {
            if (!ModelState.IsValid)
            {
                return View(userLoggingIn);
            }

            var user = await _userManager.FindByEmailAsync(userLoggingIn.Email);
            if (user == null)
            {
                TempData["Error"] = "No user is registered with given email. Please, check the email";
                return View(userLoggingIn);
            }

            var passwordCheck = await _userManager.CheckPasswordAsync(user, userLoggingIn.Password);
            if (!passwordCheck)
            {
                TempData["Error"] = "Wrong password. Please, try again";
                return View(userLoggingIn);
            }

            var res = await _signInManager.PasswordSignInAsync(user, userLoggingIn.Password, false, false);
            if (!res.Succeeded)
            {
                TempData["Error"] = "Signing in failed. Please, check your input and try again";
                return View(userLoggingIn);
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Detail(string id)
        {
            var user = await _userRepository.GetUserById(id);

            if (user == null)
            {
                var err = new ErrorViewModel()
                {
                    RequestId = $"User with id: {id} not found in DB"
                };
                return View("Error", err);
            }

            return View(user);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userRepository.GetUserById(id);

            if (user == null)
            {
                var err = new ErrorViewModel()
                {
                    RequestId = $"User with id: {id} not found in DB"
                };
                return View("Error", err);
            }

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AppUser appUser)
        {
            if (!ModelState.IsValid)
            {
                return View(appUser);
            }

            var cur = await _userManager.FindByIdAsync(appUser.Id);
            if (!cur.UserName.Equals(appUser.UserName))
            {
                cur.UserName = appUser.UserName;
            }
                cur.PhotoUrl = appUser.PhotoUrl;

            await _userManager.UpdateAsync(cur);
            await _signInManager.RefreshSignInAsync(cur);
            
            return RedirectToAction("Detail", new { id = appUser.Id });
        }
    }
}
