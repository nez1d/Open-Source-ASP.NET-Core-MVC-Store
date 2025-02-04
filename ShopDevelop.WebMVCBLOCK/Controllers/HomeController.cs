using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopDevelop.WebMVC.ViewModes;

namespace ShopDevelop.WebMVC.Controllers;

public class HomeController : Controller
{
    private Uri _baseAddress = new Uri("https://localhost:7005/api");
    private readonly HttpClient _client;
    public HomeController()
    {
        _client = new HttpClient();
        _client.BaseAddress = _baseAddress;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var productViewModel = new List<ProductViewModel>();
        HttpResponseMessage responseMessage = _client.GetAsync(
            _client.BaseAddress + "/Home/GetHomeProductList").Result;

        if (responseMessage.IsSuccessStatusCode)
        {
            string data = responseMessage.Content.ReadAsStringAsync().Result;
            productViewModel = JsonConvert.DeserializeObject<List<ProductViewModel>>(data);
        }

        return View(productViewModel);
    }
}