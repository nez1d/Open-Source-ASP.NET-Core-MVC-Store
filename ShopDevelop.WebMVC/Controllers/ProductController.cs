using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopDevelop.WebMVC.ViewModels;

namespace ShopDevelop.WebMVC.Controllers;

public class ProductController : Controller
{
    private readonly Uri address = new Uri("http://localhost:5185/api");
    private readonly HttpClient httpClient;

    public ProductController()
    {
        httpClient = new HttpClient();
        httpClient.BaseAddress = address;
    }

    [HttpGet]
    public async Task<IActionResult> Product(Guid id)
    {
        string apiRequest = $"/product/index/{id}";
        var model = new ProductViewModel();

        try
        {
            HttpResponseMessage responseMessage = httpClient
                .GetAsync(httpClient.BaseAddress + apiRequest).Result;

            if (responseMessage.IsSuccessStatusCode)
            {
                string context = await responseMessage.Content.ReadAsStringAsync();
                model = JsonConvert.DeserializeObject<ProductViewModel>(context);
            }
        }
        catch
        {
            return Redirect("/Error");
        }
        
        return View(model);
    }
}