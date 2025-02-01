using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopDevelop.Domain.Models;

namespace ShopDevelop.Identity.DuendeServer.Pages.Auth;

public class ConfirmEmail : PageModel
{
    private readonly UserManager<ApplicationUser> userManager;

    public ConfirmEmail(UserManager<ApplicationUser> userManager) =>
        this.userManager = userManager;
    
    
    public async Task<IActionResult> OnGet(string email, string code)
    {
        if (email == null)
            return BadRequest();
        
        var user = await userManager.FindByEmailAsync(email);
        
        if(user == null)
            return BadRequest("User Not Found");

        var result = await userManager.ConfirmEmailAsync(user, code);
        
        if(result.Succeeded)
            return Redirect("http://localhost:5185/index.html");
        
        return BadRequest("Email not confirmed. You need to confirm your email address.");
    }
}