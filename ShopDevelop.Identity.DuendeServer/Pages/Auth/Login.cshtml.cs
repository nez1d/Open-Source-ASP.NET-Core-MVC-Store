using Duende.IdentityServer.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopDevelop.Identity.DuendeServer.Models;
using ShopDevelop.Identity.DuendeServer.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace ShopDevelop.Identity.DuendeServer.Pages;

[AllowAnonymous]
public class LoginModel : PageModel
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public LoginModel(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager) =>
        (userManager, signInManager) = (_userManager, _signInManager);

    /*[BindProperty]
    [Required]
    public string? UserName { get; set; }
    [BindProperty]
    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
    [BindProperty]
    public bool? RememberMe { get; set; }
    [BindProperty]
    public string ReturnUrl { get; set; }*/

    [BindProperty]
    public LoginViewModel model { get; set; }

    public IActionResult OnGet()
    {
        if (this.User.Identity.IsAuthenticated)
            return Redirect("/");

        return this.Page();
    }

    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "User not found!");
                return Page();
            }
            var result = await _signInManager.PasswordSignInAsync(
                userName: user.UserName, 
                password: model.Password, 
                isPersistent: false, 
                lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return Redirect("/");
            }
            ModelState.AddModelError(string.Empty, "Login Error");
            return Page();
        }

        /*if(!string.IsNullOrWhiteSpace(UserName) 
            && UserName == Password)
        {
            var claim = new List<Claim>
            {
                new(type: "sub", value: "123"),
                new(type: "name", value: "Maxim"),
                new(type: "role", value: "Admin"),
            };

            var claimsIdentity = new ClaimsIdentity(claim, "pwd", "name", "admin");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync(claimsPrincipal);
            return LocalRedirect(ReturnUrl);
        }*/

        return Page();
    }
}
