using Duende.IdentityServer.Stores.Serialization;
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
public class RegisterModel : PageModel
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public RegisterModel(SignInManager<ApplicationUser> signInManager,
                         UserManager<ApplicationUser> userManager) =>
        (_signInManager, _userManager) = (signInManager, userManager);
    

    [BindProperty]
    public RegisterViewModel model { get; set; }

    public void OnGet() { }

    public async Task<IActionResult> OnPost()
    {
        if (ModelState.IsValid)
        {
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                EmailConfirmed = true
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var claims = new List<Claim>
                {
                    new (ClaimTypes.Name, model.Email),
                    new Claim(ClaimTypes.Role, "AuthUser")
                };

                var claimsIdentity = new ClaimsIdentity(claims, "pwd", ClaimTypes.Name, ClaimTypes.Role);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await this.HttpContext.SignInAsync(claimsPrincipal);

                return Redirect("/");
            }
            ModelState.AddModelError(string.Empty, "Error occurred");
        }
        return Page();
    }
}
