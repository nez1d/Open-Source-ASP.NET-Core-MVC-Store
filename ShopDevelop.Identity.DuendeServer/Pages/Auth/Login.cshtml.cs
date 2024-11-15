using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopDevelop.Identity.DuendeServer.Models;
using ShopDevelop.Identity.DuendeServer.ViewModels;
using System.Security.Claims;

namespace ShopDevelop.Identity.DuendeServer.Pages;

[AllowAnonymous]
public class LoginModel : PageModel
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public LoginModel(SignInManager<ApplicationUser> signInManager,
                         UserManager<ApplicationUser> userManager) =>
        (_signInManager, _userManager) = (signInManager, userManager);

    [BindProperty]
    public LoginViewModel model { get; set; }

    public async Task<IActionResult> OnPost()
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
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

            var claimsIdentity = new ClaimsIdentity(claims, "pwd", ClaimTypes.Name, ClaimTypes.Role);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await this.HttpContext.SignInAsync(claimsPrincipal);

            return Redirect("https://localhost:7226/");
        }

        return Page();
    }
}