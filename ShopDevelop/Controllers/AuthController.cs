using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopDevelop.Identity.Data;
using ShopDevelop.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using ShopDevelop.Identity.Models.User;

namespace ShopDevelop.Identity.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly AuthDbContext _context;

        public AuthController(SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager,
            AuthDbContext context) =>
            (_signInManager, _userManager, _context) =
            (signInManager, userManager, context);

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            var entity = new LoginViewModel
            {
                ReturnUrl = returnUrl
            };
            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }

            var info = await _signInManager.GetExternalLoginInfoAsync();
            var user = await _userManager.FindByLoginAsync(model.Login, info.ProviderKey);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "User not found");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(
                model.Login, model.Password, false, false);
            if (result.Succeeded)
            {
                return Redirect(model.ReturnUrl);
            }
            ModelState.AddModelError(string.Empty, "Login Error");
            return View(model);
        }

        [HttpGet]
        public IActionResult Register(string returnUrl)
        {
            var entity = new RegisterViewModel
            {
                ReturnUrl = returnUrl
            };
            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new AppUser
            {
                Login = model.Login
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return Redirect(model.Login);
            }
            ModelState.AddModelError(string.Empty, "Error occurred");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout(string returnUrl)
        {
            await _signInManager.SignOutAsync();
            return View("/Home");
        }

        public IActionResult AccessDenied()
        {

            return View();
        }
    }
}
