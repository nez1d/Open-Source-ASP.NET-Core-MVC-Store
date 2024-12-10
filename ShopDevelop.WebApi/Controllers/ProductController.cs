using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopDevelop.Application.Services.Product;
using ShopDevelop.Domain.Models;

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
            var productPage = await productService.GetByIdAsync(id);
            return Ok(productPage);
        }
        return Ok();
    }

    [HttpPost]
    [Authorize(Roles = "Manager")]
    public async Task<IActionResult> CreateProduct(Product model)
    {
        var product = await productService.AddNewProductAsync(model);
        if(product)
            return Ok(model.Id);

        return BadRequest();  
    }

    [HttpPost]
    [Authorize(Roles = "Manager")]
    public async Task<IActionResult> EditProduct(Product model)
    {
        await productService.EditProductAsync(model);
        return Ok();
    }

    [HttpPost]
    [Authorize(Roles = "Manager")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        var product = productService.DeleteProductAsync(id);

        return Ok();
    }
}