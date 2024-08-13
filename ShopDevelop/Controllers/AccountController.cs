using System.Security.Claims;
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
        private readonly IRegisterUserRepository _registerUserRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _PasswordHasher;
        private readonly UserModelView _userModel;
        private readonly JwtProvider _jwtProvider;

        public AccountController(ApplicationDbContext context, 
            IPasswordHasher passwordHasher,
            IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _registerUserRepository = new RegisterUserRepository(context, passwordHasher);
            _userRepository = new UserRepository(context);
            _userModel = new UserModelView();
        }

        public async Task<ViewResult> UserProfile(UserModelView model)
        {
            model = _userModel;
            if (model.User == null)
            {
                RedirectToAction("Login");
            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View("Register", new RegisterModelView());
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterModelView model)
        {
            if (ModelState.IsValid)
            {
                var pass = RepeatPassword(model);

                if (await pass == true)
                {
                    var register = _registerUserRepository
                        .RegisterUserByEmail(model.Login, 
                                             model.Password, 
                                             model.Email);

                    if (await register == true)
                    {
                        SetClaim(model.Login, model.Password);
                        return Redirect("/");
                    }
                }       
            }
            return View("Register", model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModelView model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.User
                .FirstOrDefault(u => u.Login == model.Login && u.Password == model.Password);

                if (user == null)
                {
                    ModelState.AddModelError("", "User not found");
                }
                else if (user.Login == model.Login || user.Password == model.Password)
                {
                    SetClaim(model.Login, model.Password);

                    var userProfileModel = _userRepository.GetUserForLogin(model.Login);

                    if (userProfileModel != null)
                    {
                        _userModel.User = await userProfileModel;

                        return View("UserProfile", _userModel);
                    }
                }
            }
            return View(model);
        }

        public async Task LogOff()
        {
            var cookie = HttpContext.Request.Cookies.ContainsKey("key");
            await HttpContext.SignOutAsync("Key");
        }  

        public async void SetClaim(string login, string password)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, login),
                new Claim(ClaimTypes.NameIdentifier, login)
            };

            var claimIdentity = new ClaimsIdentity(claims,
                Microsoft.AspNetCore.Authentication.Cookies
                .CookieAuthenticationDefaults.AuthenticationScheme);

            var claimsPrincipal = new ClaimsPrincipal(claimIdentity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                claimsPrincipal);

            /*CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddMonths(1);
            Response.Cookies.Append("login-cookie", login, option);
            Response.Cookies.Append("password-hash-cookie", password, option);*/
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
                string? cookieLogin = _httpContextAccessor.HttpContext
                    .Request.Cookies["login-cookie"];

                string? cookiePassword = _httpContextAccessor.HttpContext
                    .Request.Cookies["password-hash-cookie"];

                _userModel.User = await _userRepository
                    .GetUserForLogin(cookieLogin);

                return View("UserProfile", _userModel);               
            }
            return Redirect("Login");
        }
    }
}