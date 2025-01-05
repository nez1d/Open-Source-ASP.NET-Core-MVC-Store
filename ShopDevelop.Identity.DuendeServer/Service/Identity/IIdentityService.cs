using Microsoft.AspNetCore.Identity;
using ShopDevelop.Domain.Models;

namespace ShopDevelop.Identity.DuendeServer.Service.Identity;

public interface IIdentityService
{
    Task<ApplicationUser> GetUserById(UserManager<ApplicationUser> userManager, Guid userId);
}