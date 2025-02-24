/*using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopDevelop.Application.Services.Review;
using ShopDevelop.Identity.DuendeServer.WebAPI.Data.IdentityConfigurations;

namespace ShopDevelop.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class ReviewController : BaseController
{
    private readonly IReviewService reviewService; 
    private readonly JwtProvider jwtProvider;
    
    public ReviewController(IReviewService reviewService,
        JwtProvider jwtProvider) =>
            (this.reviewService, this.jwtProvider) = 
            (reviewService, jwtProvider);
    
    [HttpPost]
    [Authorize(Roles = "AuthUser")]
    public async Task<IActionResult> Create(Guid productId, string text, uint rating)
    {
        string accessToken = HttpContext.Request.Cookies["tasty-cookies"];
        var userId = Guid.Parse(jwtProvider.GetUserId(accessToken));
        
        if(userId == Guid.Empty)
            return BadRequest("User id is empty.");
        
        List<string> imagesUrls = new List<string>();
        
        if(rating < 1 || rating > 5)
            return BadRequest("Rating is not valid! Please try again (1-5 stars).");
        
        var result = await reviewService.CreateReviewAsync(
            userId: userId.ToString(), 
            productId: productId, 
            text: text, 
            rating: rating, 
            imagesUrls: imagesUrls);
        
        if(result)
            return Ok();
        
        return BadRequest("Invalid review.");
    }
    
    [HttpPatch]
    [Authorize(Roles = "AuthUser")]
    public async Task<IActionResult> Update(
        Guid reviewId, 
        string text,
        uint rating)
    {
        if(rating < 1 || rating > 5)
            return BadRequest("Rating is not valid! Please try again (1-5 stars).");
        
        string accessToken = HttpContext.Request.Cookies["tasty-cookies"];
        var userId = Guid.Parse(jwtProvider.GetUserId(accessToken));
        
        if(userId == Guid.Empty)
            return BadRequest("User id is empty.");
        
        var review = await reviewService.GetByIdAsync(reviewId);
        
        var imagesUrls = new List<string>();
        
        await reviewService.UpdateReviewAsync(reviewId, text, rating, imagesUrls);

        return Ok();
    }
    
    [HttpDelete]
    [Authorize(Roles = "AuthUser")]
    public async Task<IActionResult> Delete(Guid reviewId)
    {
        await reviewService.DeleteReviewAsync(reviewId);
        return Ok();
    }
    
    [HttpGet]
    [Authorize(Roles = "AuthUser")]
    public async Task<IActionResult> LikeReview(string userId, Guid reviewId)
    {
        await reviewService.LikeReviewAsync(reviewId, userId);
        return Ok();
    }
    
    [HttpGet]
    [Authorize(Roles = "AuthUser")]
    public async Task<IActionResult> GetFirstFiveByRating(Guid productId)
    {
        var result = await reviewService.GetFirstFiveByRatingAsync(productId);
        return Ok(result);
    }
    
    [HttpGet]
    [Authorize(Roles = "AuthUser")]
    public async Task<IActionResult> GetFirstFiveByDate(Guid productId)
    {
        var result = await reviewService.GetFirstFiveByDateAsync(productId);
        return Ok(result);
    }
    
    [HttpGet]
    [Authorize(Roles = "AuthUser")]
    public async Task<IActionResult> GetAllByUserId(string reviewId)
    {
        var result = await reviewService.GetAllByUserIdAsync(reviewId);
        return Ok(result);
    }
    
    [HttpGet]
    [Authorize(Roles = "AuthUser")]
    public async Task<IActionResult> GetAll()
    {
        var result = await reviewService.GetAllAsync();
        return Ok(result);
    }
}*/