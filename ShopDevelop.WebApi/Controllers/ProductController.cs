using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopDevelop.Application.Entities.Product.Commands.Create;
using ShopDevelop.Application.Entities.Product.Commands.Delete;
using ShopDevelop.Application.Entities.Product.Commands.Update;
using ShopDevelop.Application.Entities.Product.Queries.GetProductDetails;
using ShopDevelop.Domain.Dto.Product;

namespace ShopDevelop.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]/")]
public class ProductController(IMapper mapper) : BaseController
{
    [HttpPost]
    [AllowAnonymous]
    /*[Authorize(Roles = "Seller")]*/
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto model)
    {
        var command = mapper.Map<CreateClothesProductCommand>(model);
        var result = await Mediator.Send(command);

        if (result == Guid.Empty)
            return BadRequest();
            
        return Ok();
    }
    
    [HttpPut]
    /*[Authorize(Roles = "Seller")]*/
    public async Task<IActionResult> EditProduct([FromBody] UpdateProductDto model)
    {
        var command = mapper.Map<UpdateProductCommand>(model);
        await Mediator.Send(command);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    /*[Authorize(Roles = "Seller")]*/
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        var command = new DeleteProductCommand
        {
            ProductId = id,
            UserId = UserId
        };
        await Mediator.Send(command);
        return NoContent();
    }

    /*[HttpGet]
    public async Task<ActionResult<ProducListVm>> GetAllProducts()
    {
        var query = new GetProductListQuery()
        {
            UserId = UserId
        };
        var result = await Mediator.Send(query);
        return Ok();
    }*/
    
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDetailVm>> GetProductDetails(Guid id)
    {
        var query = new GetProductDetailsQuery()
        {
            Id = id
        };
        var result = await Mediator.Send(query);
        return Ok();
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDetailVm>> GetProduct(Guid id)
    {
        return Ok();
    }

    /*
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