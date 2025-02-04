using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopDevelop.WebMVC.ViewModels;

namespace ShopDevelop.WebMVC.Pages.Security;

public class Register : PageModel
{
    [BindProperty]
    public RegisterViewModel RegisterViewModel { get; set; }
    
    public async Task<IActionResult> OnPostAsync()
    {
        return Page();
    }
}