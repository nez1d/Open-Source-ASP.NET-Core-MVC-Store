using Microsoft.AspNetCore.Mvc;

namespace ShopDevelop.Blazor.WebClient.Controllers;

public class CatalogController : Controller
{
    public async Task<IActionResult> Home()
    {
        return View();
    }
}