using Duende.IdentityServer.Stores.Serialization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopDevelop.Domain.Models;
using ShopDevelop.Identity.DuendeServer.Data.IdentityConfigurations;
using ShopDevelop.Identity.DuendeServer.ViewModels;
using System.Security.Claims;

namespace ShopDevelop.Identity.DuendeServer.Pages;

[AllowAnonymous]
public class RegisterModel : PageModel
{
    private readonly SignInManager<ApplicationUser> signInManager;
    private readonly UserManager<ApplicationUser> userManager;
    private readonly JwtProvider jwtProvider;

    public RegisterModel(SignInManager<ApplicationUser> signInManager,
        UserManager<ApplicationUser> userManager) =>
        (this.signInManager, this.userManager, this.jwtProvider) = 
        (signInManager, userManager, jwtProvider = new JwtProvider());
    

    [BindProperty]
    public RegisterViewModel model { get; set; }

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
            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var claims = new List<Claim>
                {
                    new (ClaimTypes.Name, model.Email),
                    new (ClaimTypes.Role, "AuthUser"),
                    new ("UserId", user.Id.ToString())
                };

                var claimsIdentity = new ClaimsIdentity(claims, "pwd", ClaimTypes.Name, ClaimTypes.Role);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    claimsPrincipal);

                var token = jwtProvider.GenerateToken(user);

                this.HttpContext.Response.Cookies.Append("tasty-cookies", token);

                await this.HttpContext.SignInAsync(claimsPrincipal);

                return Redirect("http://localhost:5185/index.html");
            }
            ModelState.AddModelError(string.Empty, "Error occurred");
        }
        return Page();
    }


/*    public dynamic GetToken()
    {
        var handler = new JwtSecurityTokenHandler();

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AuthOptions.KEY));
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

        var identity = new ClaimsIdentity(new GenericIdentity("tasty-cookies"), 
            new[] { new Claim(ClaimTypes.Role, "AuthUser") });
        var token = handler.CreateJwtSecurityToken(subject: identity,
                                                   signingCredentials: signingCredentials,
                                                   audience: "ExampleAudience",
                                                   issuer: "ExampleIssuer",
                                                   expires: DateTime.UtcNow.AddHours(12));
        return handler.WriteToken(token);
    }*/
}
