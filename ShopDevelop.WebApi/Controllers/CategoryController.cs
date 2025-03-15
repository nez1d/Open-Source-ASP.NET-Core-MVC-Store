using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopDevelop.Application.Entities.Category.Commands.Create;
using ShopDevelop.Application.Entities.Category.Commands.Delete;
using ShopDevelop.Application.Entities.Category.Commands.Update;
using ShopDevelop.Application.Services.Category;
using ShopDevelop.Domain.Entities;


namespace ShopDevelop.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class CategoryController : BaseController
{
    private readonly ICategoryService categoryService;
    public CategoryController(ICategoryService categoryService) =>
        (this.categoryService) = (categoryService);

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
    {
        var result = await Mediator.Send(command);
        if (result != 0)
            return Created();
        
        return BadRequest();
    }

    [HttpPatch]
    public async Task<IActionResult> EditCategory(UpdateCategoryCommand model)
    {
        await Mediator.Send(model); 
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCategory(DeleteCategoryCommand command)
    {
        await Mediator.Send(command);
        return NoContent();
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        return Ok();
    }
    
    [HttpGet]
    public async Task<IActionResult> GetCategoryById(int id)
    {
        return NotFound();
    }
}