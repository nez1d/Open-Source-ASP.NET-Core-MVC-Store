using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopDevelop.Identity.DuendeServer.Data.IdentityConfigurations;
using ShopDevelop.Identity.DuendeServer.ViewModels;
using System.Security.Claims;
using ShopDevelop.Domain.Models;

namespace ShopDevelop.Identity.DuendeServer.Pages;

[AllowAnonymous]
public class LoginModel : PageModel
{
    private readonly SignInManager<ApplicationUser> signInManager;
    private readonly UserManager<ApplicationUser> userManager;
    private readonly JwtProvider jwtProvider;

    public LoginModel(SignInManager<ApplicationUser> signInManager,
                      UserManager<ApplicationUser> userManager) =>
        (this.signInManager, this.userManager, this.jwtProvider) =
        (signInManager, userManager, jwtProvider = new JwtProvider());

    [BindProperty]
    public LoginViewModel model { get; set; }

    public async Task<IActionResult> OnPost()
    {
        if (ModelState.IsValid)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "User not found!");
                return Page();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, model.Email),
                new Claim(ClaimTypes.Role, "AuthUser")
            };

            var claimsIdentity = new ClaimsIdentity(
                claims: claims, 
                authenticationType: "pwd", 
                nameType: ClaimTypes.Name, 
                roleType: ClaimTypes.Role);

            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            var token = jwtProvider.GenerateToken(user);

            this.HttpContext.Response.Cookies.Append("tasty-cookies", token);

            await this.HttpContext.SignInAsync(claimsPrincipal);

            return Redirect("https://localhost:7005/index.html");
        }
        return Page();
    }
}