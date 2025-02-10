using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopDevelop.WebMVC.ViewModels;

namespace ShopDevelop.WebMVC.Pages.Security;

public class Register : PageModel
{
    [BindProperty]
    public RegisterViewModel RegisterViewModel { get; set; }
    
    private Uri address = new Uri("http://localhost:5185/api");
    private readonly HttpClient httpClient;

    public Register()
    {
        httpClient = new HttpClient();
        httpClient.BaseAddress = address;
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        string apiRequest = "api/auth/register";
        var model = new List<CatalogViewModel>();

        /*try
        {
            HttpResponseMessage response = await httpClient.PostAsync();
        }*/
        
        return Page();
    }
}