using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopDevelop.WebMVC.ViewModels;

namespace ShopDevelop.WebMVC.Pages.Security;

public class Login : PageModel
{
    [BindProperty]
    public LoginViewModel LoginViewModel { get; set; }
    
    public async Task<IActionResult> OnPostAsync()
    {
        return Page();
    }
}