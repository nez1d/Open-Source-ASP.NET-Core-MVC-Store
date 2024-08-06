﻿using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using ShopDevelop.Web.Models;
using ShopDevelop.Data.DataBase;
using ShopDevelop.Data.Repository.Entity;
using ShopDevelop.Data.Repository.Interfaces;
using ShopDevelop.Service.Interfaces;
using ShopDevelop.Service.Entity;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ShopDevelop.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly RegisterUserRepository _registerUserRepository;
        private readonly UserRepository _userRepository;
        private readonly UserModelView _userModel;
        private readonly IPasswordHasher _PasswordHasher;
        private readonly JwtProvider _jwtProvider;
        private readonly HttpContext _httpContext;
        private IHttpContextAccessor _httpContextAccessor;

        public AccountController(ApplicationDbContext context, IPasswordHasher passwordHasher,
            IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _registerUserRepository = new RegisterUserRepository(context, passwordHasher);
            _userRepository = new UserRepository(context);
            /*_userModel = new UserModelView();*/
            GetIdentityUser();
        }

        public async Task<IActionResult> UserProfile()
        {
            UserModelView model = _userModel;

            if (model.User == null)
            {
                return Redirect("Login");
            }
            return View(_userModel);
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

            var register = _registerUserRepository
                .RegisterUserByEmail(model.Login, model.Password, model.Email);

            if (await register == true)
            {
                var pass = RepeatPassword(model);
                if (await pass == true)
                {
                    var userProfileModel = _userRepository.GetUserForLogin(model.Login);
                    _userModel.User = await userProfileModel;

                    SetClaim(model.Login, model.Password);
                    return View("UserProfile", _userModel);
                }
            }
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
                SetClaim(model.Login, model.Password);

                /*var token = _jwtProvider.GenerateToken(user);*/
                /*context.Response.Cookies.Append("tasty-cookies", token);*/

                var userProfileModel = _userRepository.GetUserForLogin(model.Login);

                if(userProfileModel != null)
                {
                    _userModel.User = await userProfileModel;

                    return View("UserProfile", _userModel);
                }

            }
            return View();
        }

        public async Task LogOff()
        {
            /*var cookie = HttpContext.Request.Cookies.ContainsKey("key");*/
            /*await HttpContext.SignOutAsync("Key");*/

            
        }  

        public async void SetClaim(string login, string password)
        {
            /*var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, login),
                new Claim(ClaimTypes.NameIdentifier, login)
            };

            var claimIdentity = new ClaimsIdentity(claims,
                Microsoft.AspNetCore.Authentication.Cookies
                .CookieAuthenticationDefaults.AuthenticationScheme);

            var claimsPrincipal = new ClaimsPrincipal(claimIdentity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                claimsPrincipal);*/

            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddMonths(1);
            Response.Cookies.Append("login-cookie", login, option);
            Response.Cookies.Append("password-hash-cookie", password, option);
        }

        public async Task<bool> RepeatPassword(RegisterModelView model)
        {
            if (model.Password == null || model.Password != model.RepeatPassword)
            {
                return false;
            }
            return true;
        }

        public async Task<IActionResult> GetIdentityUser()
        {
            if (_httpContextAccessor.HttpContext.Request.Cookies.ContainsKey("login-cookie") &&
                _httpContextAccessor.HttpContext.Request.Cookies.ContainsKey("password-hash-cookie"))
            {
                string cookieLogin = _httpContextAccessor.HttpContext.Request.Cookies["login-cookie"];
                string cookiePassword = _httpContextAccessor.HttpContext.Request.Cookies["password-hash-cookie"];
                
                return View("UserProfile", _userModel.User = 
                    await _userRepository.GetUserForLogin(cookieLogin));
                
            }
            return Redirect("Login");
        }

        /*public async Task<IActionResult> GetIdentityUser()
        {
            string name = httpContext.Request.Cookies["Cookie"];

            var userLogin = httpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;

            _userModel.User = await _userRepository.GetUserForLogin(name);

            return View("UserProfile", _userModel);



            var cookie = await httpContext.GetTokenAsync("Cookie", ClaimTypes.Name);
            var accessToken = await HttpContext.GetTokenAsync("access_token");


            var claimIdentity = new ClaimsIdentity("Cookie");
            var claimsPrincipal = new ClaimsPrincipal(claimIdentity);
            await HttpContext.GetTokenAsync("Cookie");


                    /*var cookie = HttpContext.GetRouteValue("Cookie");
            var cookies = HttpContext.GetTokenAsync(ClaimTypes.NameIdentifier);

            _userModel.User = await _userRepository.GetUserForLogin(cookie.ToString());

        _userModel.User = await _userRepository.GetUserForLogin(cookie);
        }*/

        /// <summary>
        /// ДОДЕЛАТЬ ЗАГРУЗКУ СТРАНИЦЫ ВОШЕДШЕГО ЮСЕР ПРОФИЛЯ ЗАГРУЗКУ ПРОФИЛЯ.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> GetClaim()
        {          
            return View("UserProfile", _userModel);
        }
    }
}