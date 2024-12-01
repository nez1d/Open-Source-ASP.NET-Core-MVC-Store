using Microsoft.AspNetCore.Mvc;
using ShopDevelop.Application.Services.Product;

namespace ShopDevelop.WebApi.Controllers;

[Route("api/[controller]/[action]/{id?}")]
[ApiController]
public class ProductController : BaseController
{
    private readonly IProductService productService;
    public ProductController(IProductService productService) =>
        this.productService = productService;

    [HttpGet]
    public async Task<IActionResult> Index(Guid? id)
    {
        if(id != null)
        {
            var productPage = await productService.GetById(id);
            return Ok(productPage);
        }
        return Ok();
    }
}