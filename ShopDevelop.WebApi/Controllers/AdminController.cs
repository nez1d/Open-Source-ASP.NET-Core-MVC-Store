/*using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace ShopDevelop.WebApi.Controllers;

[ApiController]
[Route("{id}/[controller]/[action]")]
public class AdminController : BaseController
{
    private readonly RoleManager<IdentityRole> roleManager;
    public AdminController(RoleManager<IdentityRole> roleManager) =>
        this.roleManager = roleManager;

    public async Task<IActionResult> GetRoles()
    {
        await roleManager.CreateAsync(new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" });
        return Ok(await roleManager.Roles.ToListAsync());
    }
}
*/