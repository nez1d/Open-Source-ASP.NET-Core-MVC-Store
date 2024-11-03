using Microsoft.AspNetCore.Mvc;
using ShopDevelop.Application.Services.Product;

namespace ShopDevelop.WebApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class HomeController : BaseController
{
    private readonly IProductService productService;
    public HomeController(IProductService productService) =>
            this.productService = productService;

    [HttpGet]
    public async Task<ActionResult> GetHomeProductList()
    {
        var products = await productService.GetAllProducts();
        return Ok(products);
    }
}