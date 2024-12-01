/*using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using ShopDevelop.Application.Data.Common.Exceptions;
using ShopDevelop.Domain.Models;

namespace ShopDevelop.WebApi.Controllers;

public class RoleAdminController : BaseController
{
    private readonly RoleManager<IdentityRole> roleManager;
    private readonly UserManager<ApplicationUser> userManager;
    
    public RoleAdminController(RoleManager<IdentityRole> roleManager,
        UserManager<ApplicationUser> userManager) => 
        (this.roleManager, this.userManager) = (roleManager, userManager);

    public async Task<IActionResult> Create([Required] string name)
    {
        if (ModelState.IsValid)
        {
            IdentityResult result = await roleManager.CreateAsync(new IdentityRole(name));
            if (result.Succeeded)
            {
                return Ok();
                
            }
        }
        return Redirect("/");
    }

    public async Task<IActionResult> Delete(string id)
    {
        IdentityRole role = await roleManager.FindByIdAsync(id);
        if (role != null)
        {
            IdentityResult result = await roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Role not found");
            }
        }
        return Redirect("/");
    }

    public async Task<IActionResult> Edit(string id)
    {
        throw new Exception();
    }
}*/