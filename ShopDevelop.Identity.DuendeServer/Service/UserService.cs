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

    public UserService(UserManager<ApplicationUser> userManager,
        JwtProvider jwtProvider) =>
            (this.userManager, this.jwtProvider) = 
            (userManager, jwtProvider);

    public async Task Register(string email, string password) { }

    public async Task<string> Login( 
        string email, 
        string password)
    {
        var user = await userManager.FindByEmailAsync(email);

        if (user != null)
        {
            var token = jwtProvider.GenerateToken(user);
            return token;
        }
        
        return "";
    }
}