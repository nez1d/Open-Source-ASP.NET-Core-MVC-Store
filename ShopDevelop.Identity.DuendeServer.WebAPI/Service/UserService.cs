using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using ShopDevelop.Domain.Entities;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using ShopDevelop.Identity.DuendeServer.WebAPI.Data.IdentityConfigurations;

namespace ShopDevelop.Identity.DuendeServer.WebAPI.Service;

public class UserService : ControllerBase
{
    private readonly UserManager<ApplicationUser> userManager;
    private readonly JwtProvider jwtProvider;
    private readonly IHttpContextAccessor httpContextAccessor;

    public UserService(JwtProvider jwtProvider,
        UserManager<ApplicationUser> userManager,
        IHttpContextAccessor httpContextAccessor)
    {
        this.userManager = userManager;
        this.jwtProvider = jwtProvider;
        this.httpContextAccessor = httpContextAccessor;
    }

    public async Task<bool> Register(string email, string password)
    {
        var userExist = await userManager.FindByEmailAsync(email);
        if (userExist != null)
            return false;
        
        var user = new ApplicationUser
        {    
            UserName = email,
            Email = email
        };
            
        var result = await userManager.CreateAsync(user, password);

        if (result.Succeeded)
        {
            bool emailStatus = await CheckEmailConfirmed(email);

            if (emailStatus)
                return false;

            var loginResult = await this.Login(user.Email, user.PasswordHash);

            if (!loginResult)
                return false;
        }
        return true;
    }

    public async Task<bool> Login(string email, string password)
    {
        var user = await userManager.FindByEmailAsync(email);
        
        if(user == null)
            return false;
        
        var result = await userManager.CheckPasswordAsync(user, password);
        
        if(result)
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
    
    public async Task ConfirmEmail(string email)
    {
        /*var user = await userManager.FindByEmailAsync(email);

        if (user == null)
            return;
        
        var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
        
        var confirmationLink = urlHelper.Action(
            action: "ConfirmEmail",
            controller: "Auth",
            values: new { email = email, code = code },
            protocol: httpContextAccessor.HttpContext.Request.Scheme);
        
        await emailService.SendEmailAsync(
            email: email, 
            subject: "Confirm Email",
            message: $"<a href=''>link</a>");*/
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