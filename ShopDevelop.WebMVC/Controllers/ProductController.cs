using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopDevelop.WebMVC.ViewModes;

namespace ShopDevelop.WebMVC.Controllers;

public class ProductController : Controller
{
    private Uri _baseAddress = new Uri("https://localhost:7005/api");
    private readonly HttpClient _client;
    public ProductController()
    {
        _client = new HttpClient();
        _client.BaseAddress = _baseAddress;
    }

    [HttpGet]
    public async Task<IActionResult> Index(Guid id)
    {
        var productViewModel = new ProductPageViewModel();
        HttpResponseMessage responseMessage = _client.GetAsync(
            _client.BaseAddress + $"/Product/Index/{id}").Result;

        if (responseMessage.IsSuccessStatusCode)
        {
            string data = responseMessage.Content.ReadAsStringAsync().Result;
            productViewModel = JsonConvert.DeserializeObject<ProductPageViewModel>(data);
        }

        return View(productViewModel);
    }
}