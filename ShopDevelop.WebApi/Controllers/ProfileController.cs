using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShopDevelop.Application.Services.User;
using ShopDevelop.Domain.Models;
using ShopDevelop.Persistence.Repository;

namespace ShopDevelop.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]/{id}")]
public class ProfileController : BaseController
{
    private readonly IUserService userService;
    public ProfileController(UserService userService) =>
        this.userService = userService;
        
    [HttpGet]
    [Authorize(Roles = "AuthUser")]
    public async Task<IActionResult> UserProfile(Guid id)
    {
        if (id != null)
        {
            var profile = userService.GetUserProfile(id);
            return Ok(profile);
        }
        return Ok();
    }
}