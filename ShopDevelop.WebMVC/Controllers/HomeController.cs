using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopDevelop.WebMVC.ViewModels;

namespace ShopDevelop.WebMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger logger;
    private readonly Uri address = new Uri("http://localhost:5185/api");
    private readonly HttpClient httpClient;

    public HomeController(ILogger<HomeController> logger)
    {
        this.logger = logger;
        httpClient = new HttpClient();
        httpClient.BaseAddress = address;
    }
    
    [HttpGet]
    public async Task<ActionResult> Index()
    {
        string apiRequest = "/Home/GetHomeProductList";
        var model = new List<CatalogViewModel>();
        
        try
        {
            HttpResponseMessage responseMessage = httpClient
                .GetAsync(httpClient.BaseAddress + apiRequest).Result;

            if (responseMessage.IsSuccessStatusCode)
            {
                string content = await responseMessage.Content.ReadAsStringAsync();
                model = JsonConvert.DeserializeObject<List<CatalogViewModel>>(content);
            }    
        }
        catch (Exception ex)
        {
            return Redirect("/Error");
        }

        return View(model);
    }
}