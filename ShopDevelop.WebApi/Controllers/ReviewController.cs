using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopDevelop.Application.Entities.Review.Commands.Create;
using ShopDevelop.Application.Entities.Review.Commands.Delete;
using ShopDevelop.Application.Entities.Review.Commands.Update;
using ShopDevelop.Application.Entities.Review.Queries.GetAllByProductId;
using ShopDevelop.Application.Entities.Review.Queries.GetAllReviews;
using ShopDevelop.Application.Entities.Review.Queries.GetAllReviewsByUserId;
using ShopDevelop.Application.Entities.Review.Queries.GetFirstByCreatedDate;
using ShopDevelop.Application.Entities.Review.Queries.GetFirstByRating;
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
    public async Task<IActionResult> Edit([FromBody] UpdateReviewDto model)
    {
        var review = mapper.Map<UpdateReviewCommand>(model);
        await Mediator.Send(review);
        return NoContent();
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
        var result = await Mediator.Send(new GetAllReviewsQuery());
        if (result != null)
            return Ok(result);
        
        return NotFound();
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAllByProductId(Guid id)
    {
        var result = await Mediator.Send(
            new GetAllReviewsByProductIdQuery()
            {
                ProductId = id
            });
        
        if (result != null)
            return Ok(result);
        
        return NotFound();
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAllByUserId(Guid id)
    {
        var result = await Mediator.Send(
        new GetAllReviewsByUserIdQuery()
        {
            UserId = id.ToString()
        });
        
        if (result != null)
            return Ok(result);
        
        return NotFound();
    }
    
    [HttpGet("{productId}/{count}")]
    public async Task<IActionResult> GetFirstByRating(Guid productId, int count)
    {
        var request = await Mediator.Send(
            new GetFirstReviewsByRatingQuery()
            {
                ProductId = productId, 
                Count = count
            });
        
        if(request != null)
            return Ok(request);
        
        return NotFound();
    }
    
    [HttpGet("{productId}/{count}")]
    public async Task<IActionResult> GetFirstByDate(Guid productId, int count)
    {
        var request = await Mediator.Send(
            new GetFirstReviewsByDateQuery()
            {
                ProductId = productId, 
                Count = count
            });
        
        if(request != null)
            return Ok(request);
        
        return NotFound();
    }
    
    [HttpPost("{reviewId}/{userId}")]
    public async Task<IActionResult> LikeReview(Guid reviewId, Guid userId)
    {
        // TODO: доделать лайк отзыва
        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> UnlikeReview()
    {
        // TODO: доделать снятие лайка с отзыва
        return Ok();
    }
}