using Microsoft.AspNetCore.Mvc;

namespace ShopDevelop.WebMVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}