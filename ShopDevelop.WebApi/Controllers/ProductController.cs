using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopDevelop.Application.Entities.Product.Commands.Create;
using ShopDevelop.Domain.Dto.Product;

namespace ShopDevelop.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]/")]
public class ProductController(IMapper mapper) : BaseController
{
    [HttpPost]
    /*[Authorize(Roles = "AuthUser")]*/
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> CreateClothesProduct(CreateClothesProductDto model)
    {
        try
        {
            var command = mapper.Map<CreateClothesProductCommand>(model);
            var result = await Mediator.Send(command);
        }
        catch (Exception ex) { }
        
        return Ok();
    }

    /*[HttpPatch]
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
    }*/
}