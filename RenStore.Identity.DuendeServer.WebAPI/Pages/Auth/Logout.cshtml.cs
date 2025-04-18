using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RenStore.Identity.DuendeServer.WebAPI.Pages.Auth;

public class LogoutModel : PageModel
{
    public async Task<IActionResult> OnGet()
    {
        await this.HttpContext.SignOutAsync();
        return Redirect("/");
    }
}