using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopDevelop.Application.Entities.Product.Commands.Create.Clothes;
using ShopDevelop.Application.Entities.Product.Commands.Create.Shoes;
using ShopDevelop.Application.Entities.Product.Commands.Delete;
using ShopDevelop.Application.Entities.Product.Commands.Update;
using ShopDevelop.Application.Entities.Product.Queries.GetMinimizedProducts;
using ShopDevelop.Application.Entities.Product.Queries.GetProductDetails;
using ShopDevelop.Domain.Dto.Product;

namespace ShopDevelop.WebApi.Controllers;

[ApiController]
[ApiVersion(1, Deprecated = false)]
[Route("api/v{version:apiVersion}/[controller]/[action]")]
public class ProductController(IMapper mapper) : BaseController
{
    [HttpPost]
    [AllowAnonymous]
    [MapToApiVersion(1)]
    public async Task<IActionResult> CreateClothes([FromBody] CreateClothesProductDto model)
    {
        var command = mapper.Map<CreateClothesProductCommand>(model);
        var result = await Mediator.Send(command);

        if (result == Guid.Empty)
            return BadRequest();

        return Created();
    }
    
    [HttpPost]
    [AllowAnonymous]
    [MapToApiVersion(1)]
    public async Task<IActionResult> CreateShoes([FromBody] CreateShoesProductDto model)
    {
        var command = mapper.Map<CreateShoesProductCommand>(model);
        var result = await Mediator.Send(command);

        if (result == Guid.Empty)
            return BadRequest();
        
        return Ok();
    }
    
    [HttpPut]
    [AllowAnonymous]
    [MapToApiVersion(1)]
    public async Task<IActionResult> Edit([FromBody] UpdateProductDto model)
    {
        var command = mapper.Map<UpdateProductCommand>(model);
        await Mediator.Send(command);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    [AllowAnonymous]
    [MapToApiVersion(1)]
    public async Task<IActionResult> Delete([FromBody] DeleteProductCommand command)
    {
        await Mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [AllowAnonymous]
    [MapToApiVersion(1)]
    public async Task<ActionResult> Get()
    {
        var result = await Mediator.Send(
            new GetMiniProductListQuery());
        return Ok(result);
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    [MapToApiVersion(1)]
    public async Task<ActionResult> Get(Guid id)
    {
        var byIdQuery = new GetProductByIdQuery
        {
            Id = id
        };
        var result = await Mediator.Send(byIdQuery);
        
        if(result != null)
            return Ok(result);
        
        return NotFound();
    }
}