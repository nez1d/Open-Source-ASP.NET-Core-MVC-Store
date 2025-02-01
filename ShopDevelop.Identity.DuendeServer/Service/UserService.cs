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

namespace ShopDevelop.Identity.DuendeServer.Service;

public class UserService 
{
    private readonly UserManager<ApplicationUser> userManager;
    private readonly JwtProvider jwtProvider;
    private readonly SignInManager<ApplicationUser> signInManager;
    private readonly IHttpContextAccessor httpContextAccessor;

    public UserService(UserManager<ApplicationUser> userManager,
        JwtProvider jwtProvider,
        SignInManager<ApplicationUser> signInManager,
        IHttpContextAccessor httpContextAccessor) =>
            (this.userManager, this.jwtProvider, this.signInManager, 
                this.httpContextAccessor) = 
            (userManager, jwtProvider, signInManager, 
                httpContextAccessor);

    public async Task Register(string email, string password) { }

    public async Task<bool> LogIn(string email, string password)
    {
        var user = await userManager.FindByEmailAsync(email);
        
        if(user == null)
            return false;

        var claims = new List<Claim>
        {
            new (ClaimTypes.Name, email),
            new (ClaimTypes.Role, "AuthUser"),
            new ("UserId", user.Id)
        };

        var claimsIdentity = new ClaimsIdentity(claims, "pwd", ClaimTypes.Name, ClaimTypes.Role);
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

        await httpContextAccessor.HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            claimsPrincipal);

        var token = jwtProvider.GenerateToken(user);

        httpContextAccessor.HttpContext.Response.Cookies.Append("tasty-cookies", token);

        await httpContextAccessor.HttpContext.SignInAsync(claimsPrincipal);

        return true;
    }

    public async Task<bool> CheckEmailConfirmed(string email)
    {
        var user = await userManager.FindByEmailAsync(email);
        if (user != null)
        {
            bool emailStatus = await userManager.IsEmailConfirmedAsync(user);
            
            if (emailStatus)
                return true;
        }
        return false;
    }
}