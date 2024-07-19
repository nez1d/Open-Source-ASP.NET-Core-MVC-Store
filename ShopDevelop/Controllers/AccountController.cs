using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using ShopDevelop.Web.Models;
using ShopDevelop.Data.DataBase;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using ShopDevelop.Data.Repository.Entity;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.ComponentModel;

namespace ShopDevelop.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly RegisterUserRepository _registerUserRepository;

        public  AccountController(ApplicationDbContext context)
        {
            _context = context;
            _registerUserRepository = new RegisterUserRepository(context);
        }   

        public IActionResult UserProfile()
        {
            return View();
        }
        
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterModelView model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var registerEmail = _registerUserRepository
                .RegisterUserByEmail(model.Name, model.Password, model.Email);

            if (await registerEmail == true)
            {
                SetClaim(model.Name);
                return View("UserProfile", registerEmail);
            }
            /*else
            {
                var registerPhone = _registerUserRepository
                .RegisterUserByEmail(model.Name, model.Password, model.PhoneNumber);

                if (await registerPhone == true)
                {
                    SetClaim(model.Name);
                    return View("UserProfile", registerPhone);
                }
            }*/
            return RedirectToAction("Register");
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModelView model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = _context.User
                .FirstOrDefault(u => u.Login == model.Login && u.Password == model.Password);

            if (user == null) 
            {
                ModelState.AddModelError("", "User not found");
            }
            else if(user.Login == model.Login || user.Password == model.Password)
            {
                SetClaim(model.Login);
                return View("UserProfile", model);
            }
            return View();
        }

        public IActionResult LogOff() 
        {
            HttpContext.SignOutAsync("Cookie");
            return Redirect("/Home/Index");
        }

        public async void RepeatPassword(string password)
        {

        }

        public async void SetClaim(string name)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, name)
            };

            var claimIdentity = new ClaimsIdentity(claims, "Cookie");
            var claimsPrincipal = new ClaimsPrincipal(claimIdentity);
            await HttpContext.SignInAsync("Cookie", claimsPrincipal);
        }
    }
}
