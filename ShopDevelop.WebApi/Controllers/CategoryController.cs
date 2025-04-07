using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopDevelop.Application.Entities.Category.Commands.Create;
using ShopDevelop.Application.Entities.Category.Commands.Delete;
using ShopDevelop.Application.Entities.Category.Commands.Update;
using ShopDevelop.Application.Entities.Category.Queries.GetAllCategories;
using ShopDevelop.Application.Entities.Category.Queries.GetCategoryById;
using ShopDevelop.Application.Entities.Category.Queries.GetCategoryByName;
using ShopDevelop.Application.Services.Category;
using ShopDevelop.Domain.Entities;


namespace ShopDevelop.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class CategoryController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
    {
        var result = await Mediator.Send(command);
        if (result != 0)
            return Created();
        
        return BadRequest();
    }

    [HttpPut]
    public async Task<IActionResult> EditCategory([FromBody] UpdateCategoryCommand model)
    {
        await Mediator.Send(model); 
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCategory([FromBody] DeleteCategoryCommand command)
    {
        await Mediator.Send(command);
        return NoContent();
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var result = await Mediator
            .Send(new GetCategoriesListQuery());
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById(int id)
    {
        var result = await Mediator.Send(
            new GetCategoryByIdQuery()
            {
                Id = id
            });
        return Ok(result);
    }
    
    [HttpGet("{name}")]
    public async Task<IActionResult> GetCategoryByName(string name)
    {
        var result = await Mediator.Send(
            new GetCategoryByNameQuery()
            {
                Name = name
            });
        return Ok(result);
    }
}