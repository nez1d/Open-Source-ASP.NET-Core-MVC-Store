using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using ShopDevelop.Domain.Models;

namespace ShopDevelop.Application.Services.Identity;

public class IdentityService /*: IIdentityService*/
{
    private readonly UserManager<ApplicationUser> userManager;
    public IdentityService(UserManager<ApplicationUser> userManager) => 
        (this.userManager) = (userManager);

    public async Task<ApplicationUser> GetUserById(Guid userId)
    {
        return await userManager.FindByIdAsync(userId.ToString());
    }
    /*private readonly UserManager<ApplicationUser> userManager;
    private readonly IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory;
    private readonly IAuthorizationService authorizationService;

    public IdentityService(
        UserManager<ApplicationUser> userManager,
        IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory,
        IAuthorizationService authorizationService) =>
            (this.userManager, this.userClaimsPrincipalFactory, this.authorizationService) =
            (userManager, userClaimsPrincipalFactory, authorizationService);

    public async Task<Guid> CreateUserAsync(string userName, string password)
    {
        var user = new ApplicationUser
        {
            UserName = userName,
            Password = password,
            EmailConfirmed = true
        };

        var result = await userManager.CreateAsync(user, password);
        return user.Id;
    }

    public async Task DeleteUserAsync(Guid userId)
    {
        var user = await userManager.FindByIdAsync(userId);

        if (user != null)
        {
            await DeleteUserAsync(userId);
        }
    }

    public async Task<bool> AuthorizeAsync(Guid userId, string policyName)
    {
        var user = await userManager.FindByIdAsync(userId);

        if (user == null)
        {
            return false;
        }

        var principal = await _userClaimsPrincipalFactory.CreateAsync(user);

        var claims = new List<Claim>
        {
            new (ClaimTypes.Name, model.Email),
            new Claim(ClaimTypes.Role, "AuthUser")
        };

        var claimsIdentity = new ClaimsIdentity(claims, "pwd", ClaimTypes.Name, ClaimTypes.Role);
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

        var result = await authorizationService.AuthorizeAsync(claimsPrincipal, policyName);

        return result.Succeeded;
    }

    public async Task<bool> IsInRoleAsync(Guid userId, string role)
    {
        var user = await userManager.FindByIdAsync(userId);

        return user != null && await userManager.IsInRoleAsync(user, role);
    }

    public async Task<string?> GetUserNameAsync(Guid userId)
    {
        var user = await userManager.FindByIdAsync(userId);

        return user?.UserName;
    }*/
}