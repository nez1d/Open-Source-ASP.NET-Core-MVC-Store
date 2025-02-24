using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopDevelop.WebMVC.ViewModels;

namespace ShopDevelop.WebMVC.Pages.Security;

public class Login : PageModel
{
    private readonly HttpClient httpClient;
    private readonly string urlBase = "http://localhost:5261/";
    
    public Login(HttpClient httpClient) => 
        this.httpClient = httpClient;
    
    [BindProperty]
    public LoginViewModel LoginViewModel { get; set; }
    
    public async Task<IActionResult> OnPost()
    {
        httpClient.BaseAddress = new Uri(urlBase);
        HttpResponseMessage response = await httpClient.PostAsJsonAsync(urlBase + "/api/auth/", LoginViewModel);

        if (response.IsSuccessStatusCode)
            return Page();
        
        return RedirectToPage("/");
    }
}