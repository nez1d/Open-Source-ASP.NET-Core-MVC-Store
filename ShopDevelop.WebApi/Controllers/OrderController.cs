using Microsoft.AspNetCore.Mvc;

namespace ShopDevelop.WebApi.Controllers;

[Route("api/[controller]/[action]/")]
[ApiController]
public class OrderController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create()
    {
        return BadRequest();
    }
    
    [HttpPut]
    public async Task<IActionResult> Edit()
    {
        return Ok();
    }
    
    [HttpDelete]
    public async Task<IActionResult> Delete()
    {
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok();
    }
    
    [HttpGet]
    public async Task<IActionResult> GetById()
    {
        return Ok();
    }
    
    [HttpGet]
    public async Task<IActionResult> GetByUserId()
    {
        return Ok();
    }
}