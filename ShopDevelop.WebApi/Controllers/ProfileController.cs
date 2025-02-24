/*using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShopDevelop.Persistence.Repository;

namespace ShopDevelop.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]/{id}")]
public class ProfileController : BaseController
{
    /*private readonly IUserService userService;
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
    
    [HttpGet]
    [Authorize(Roles = "AuthUser")]
    public async Task<IActionResult> EditProfile(Guid id)
    {
        return Ok();
    }

    [HttpPost]
    [Authorize(Roles = "AuthUser")]
    public async Task<IActionResult> DeleterProfile(Guid id)
    {
        return Ok();
    }

    [HttpPost]
    [Authorize(Roles = "AuthUser")]
    public async Task<IActionResult> Logout(Guid id)
    {
        return Ok();
    }#1#
}*/