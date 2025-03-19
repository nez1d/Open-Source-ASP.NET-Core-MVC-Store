using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopDevelop.Application.Entities.Review.Commands.Create;
using ShopDevelop.Application.Entities.Review.Commands.Delete;
using ShopDevelop.Domain.Dto.Review;

namespace ShopDevelop.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class ReviewController(IMapper mapper) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateReviewDto model)
    {
        var review = mapper.Map<CreateReviewCommand>(model);
        var result = await Mediator.Send(review);
        if(result != Guid.Empty)
            return Created();
        
        return BadRequest();
    }
    
    [HttpPut]
    public async Task<IActionResult> Edit()
    {
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await Mediator.Send(new DeleteReviewCommand { Id = id });
        return NoContent();
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok();
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllByUserId()
    {
        return Ok();
    }
    
    [HttpGet]
    public async Task<IActionResult> GetFirstFiveByRating()
    {
        return Ok();
    }
    
    [HttpGet]
    public async Task<IActionResult> GetFirstFiveByDate()
    {
        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> LikeReview()
    {
        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> UnlikeReview()
    {
        return Ok();
    }
}