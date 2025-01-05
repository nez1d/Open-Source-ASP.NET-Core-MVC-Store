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

namespace ShopDevelop.Identity.DuendeServer.Service.Identity;

public class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> userManager;
    public IdentityService(UserManager<ApplicationUser> userManager) => 
        this.userManager = userManager;

    public async Task<ApplicationUser> GetUserById(
        UserManager<ApplicationUser> userManager, Guid userId)
    {
        return await userManager.FindByIdAsync(userId.ToString());
    }
}