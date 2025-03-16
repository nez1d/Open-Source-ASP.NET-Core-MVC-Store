using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopDevelop.Application.Entities.Product.Commands.Create.Clothes;
using ShopDevelop.Application.Entities.Product.Commands.Create.Shoes;
using ShopDevelop.Application.Entities.Product.Commands.Delete;
using ShopDevelop.Application.Entities.Product.Commands.Update;
using ShopDevelop.Application.Entities.Product.Queries.GetMinimizedProducts;
using ShopDevelop.Application.Entities.Product.Queries.GetProduct;
using ShopDevelop.Application.Entities.Product.Queries.GetProductDetails;
using ShopDevelop.Domain.Dto.Product;

namespace ShopDevelop.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]/")]
public class ProductController(IMapper mapper) : BaseController
{
    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> CreateClothes([FromBody] CreateClothesProductDto model)
    {
        var command = mapper.Map<CreateClothesProductCommand>(model);
        var result = await Mediator.Send(command);

        if (result == Guid.Empty)
            return BadRequest();

        return Ok();
    }
    
    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
    public async Task<IActionResult> Edit([FromBody] UpdateProductDto model)
    {
        var command = mapper.Map<UpdateProductCommand>(model);
        await Mediator.Send(command);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> Delete([FromBody] DeleteProductCommand command)
    {
        await Mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<ProductMiniListVm>> ProductsList()
    {
        var query = new GetMiniProductListQuery()
        {
            Id = UserId
        };
        var result = await Mediator.Send(query);
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<ProductVm>> Product([FromBody] GetProductQuery query)
    {
        var result = await Mediator.Send(query);
        return Ok(result);
    }
}