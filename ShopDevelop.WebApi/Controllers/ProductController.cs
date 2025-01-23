using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopDevelop.Application.Services.Product;
using ShopDevelop.Domain.Models;

namespace ShopDevelop.WebApi.Controllers;

[Route("api/[controller]/[action]/")]
[ApiController]
public class ProductController : BaseController
{
    private readonly IProductService productService;
    public ProductController(IProductService productService) =>
        this.productService = productService;

    [HttpPost]
    [Authorize(Roles = "AuthUser")]
    public async Task<IActionResult> CreateProduct(
        string name, decimal price, decimal oldPrice,
        string description, string shortDescription, 
        uint inStock, bool isAvailable, string categoryName,
        Guid sellerId)
    {
        var product = new Product
        {
            ProductName = name,
            Price = price,
            OldPrice = oldPrice,
            Description = description,
            ShortDescription = shortDescription,
            InStock = inStock,
            IsAvailable = isAvailable,
        };
        var data = await productService.AddNewProductAsync(product, categoryName, sellerId);
        return Ok();
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
    
    [HttpGet]
    [Route("api/[controller]/[action]/{id?}")]
    public async Task<IActionResult> Index(Guid? id)
    {
        if(id != null)
        {
            var productPage = await productService.GetByIdAsync(id);
            return Ok(productPage);
        }
        return Ok();
    }
}