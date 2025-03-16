using Microsoft.AspNetCore.Mvc;
using ShopDevelop.Application.Entities.Seller.Command.Create;
using ShopDevelop.Application.Entities.Seller.Command.Delete;

namespace ShopDevelop.WebApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class SellerController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> CreateSeller([FromBody] CreateSellerCommand createSellerCommand)
    {
        var result = await Mediator.Send(createSellerCommand);
        if(result is not 0)
            return Ok(result);
        
        return BadRequest();
    }

    [HttpPost]
    public async Task<IActionResult> EditSeller(Guid id)
    {
        return NoContent();  
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteSeller([FromBody] DeleteSellerCommand deleteSellerCommand)
    {
        await Mediator.Send(deleteSellerCommand);
        return NoContent();
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllSellers()
    {
        return Ok();
    }
    
    [HttpGet]
    public async Task<IActionResult> GetSellerById()
    {
        return Ok();
    }
    
    [HttpGet]
    public async Task<IActionResult> GetSellerByName()
    {
        return Ok();
    }
}