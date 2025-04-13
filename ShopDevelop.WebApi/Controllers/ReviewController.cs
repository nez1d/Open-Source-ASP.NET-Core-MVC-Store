using Asp.Versioning;
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
[ApiVersion(1, Deprecated = false)]
[Route("api/v{version:apiVersion}/[controller]")]
public class ReviewController(IMapper mapper) : BaseController
{
    [HttpPost]
    [MapToApiVersion(1)]
    [Route("/api/v{version:apiVersion}/review")]
    public async Task<IActionResult> Create([FromBody] CreateReviewDto model)
    {
        var review = mapper.Map<CreateReviewCommand>(model);
        var result = await Mediator.Send(review);
        
        if(result != Guid.Empty)
            return Created();
        
        return BadRequest();
    }
    
    // TODO: доделать
    [HttpPatch]
    [MapToApiVersion(1)]
    [Route("/api/v{version:apiVersion}/review/{id:guid}")]
    public async Task<IActionResult> Edit(Guid id, [FromBody] UpdateReviewDto model)
    {
        var review = mapper.Map<UpdateReviewCommand>(model);
        await Mediator.Send(review);
        return NoContent();
    }

    [HttpDelete]
    [MapToApiVersion(1)]
    [Route("/api/v{version:apiVersion}/review/{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await Mediator.Send(new DeleteReviewCommand { Id = id });
        return NoContent();
    }

    [HttpGet]
    [MapToApiVersion(1)]
    [Route("/api/v{version:apiVersion}/reviews")]
    public async Task<IActionResult> GetAll()
    {
        var result = await Mediator.Send(new GetAllReviewsQuery());
        if (result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet]
    [MapToApiVersion(1)]
    [Route("/api/v{version:apiVersion}/product-reviews/{productId:guid}")]
    public async Task<IActionResult> GetByProductId(Guid productId)
    {
        var result = await Mediator.Send(
            new GetAllReviewsByProductIdQuery()
            {
                ProductId = productId
            });

        if (result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet]
    [MapToApiVersion(1)]
    [Route("/api/v{version:apiVersion}/user-reviews/{userId:guid}")]
    public async Task<IActionResult> GetByUserId(string userId)
    {
        var result = await Mediator.Send(
        new GetAllReviewsByUserIdQuery()
        {
            UserId = userId
        });

        if (result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet]
    [MapToApiVersion(1)]
    [Route("/api/v{version:apiVersion}/product-reviews-by-rating/{productId:guid}/{count:int}")]
    public async Task<IActionResult> GetFirstByRating(Guid productId, int count)
    {
        var request = await Mediator.Send(
            new GetFirstReviewsByRatingQuery()
            {
                ProductId = productId,
                Count = count
            });

        if(request is null)
            return NotFound();

        return Ok(request);
    }

    [HttpGet]
    [MapToApiVersion(1)]
    [Route("/api/v{version:apiVersion}/product-reviews-by-date/{productId:guid}/{count:int}")]
    public async Task<IActionResult> GetFirstByDate(Guid productId, int count)
    {
        var request = await Mediator.Send(
            new GetFirstReviewsByDateQuery()
            {
                ProductId = productId,
                Count = count
            });

        if(request is null)
            return NotFound();

        return Ok(request);
    }
    // TODO: переделать
    [HttpPost]
    [MapToApiVersion(1)]
    [Route("/api/v{version:apiVersion}/like-review/{reviewId:guid}/{userId}")]
    public async Task<IActionResult> LikeReview(Guid reviewId, string userId)
    {
        // TODO: доделать лайк отзыва
        return Ok();
    }
    // TODO: переделать
    [HttpPost]
    [MapToApiVersion(1)]
    [Route("/api/v{version:apiVersion}/ulike-review/{reviewId:guid}/{userId}")]
    public async Task<IActionResult> UnlikeReview()
    {
        // TODO: доделать снятие лайка с отзыва
        return Ok();
    }
}