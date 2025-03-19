using ShopDevelop.Application.Repository;

namespace ShopDevelop.Application.Services.Review;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository reviewRepository;
    public ReviewService(IReviewRepository reviewRepository) => 
        this.reviewRepository = reviewRepository;
    
    public async Task<bool> CreateReviewAsync(
        string userId,
        Guid productId,
        string text,
        uint rating,
        List<string> imageUrls,
        CancellationToken cancellationToken)
    {
        var likesUsersId = new List<string>();
        var review = new Domain.Entities.Review
        {
            ProductId = productId,
            Message = text,
            Rating = rating,
            ApplicationUserId = userId,
            CreatedDate = DateTime.UtcNow,
            LastUpdatedDate = null,
            IsUpdated = false,
            ImagesUrls = imageUrls,
            LikesCount = 0,
            UsersLikedIds = likesUsersId
        };
        
        var check = await reviewRepository.CheckExistByUserId(productId, userId);

        if (!check)
            return false;
        
        var result = await reviewRepository.Create(review, cancellationToken);
        
        if(result != Guid.Empty)
            return true;
        
        return false;
    }

    public async Task UpdateReviewAsync(
        Guid reviewId,
        string text,
        uint rating,
        List<string> imageUrls)
    {
        var review = await GetByIdAsync(reviewId);

        if (review == null)
            return;
        
        review.Message = text;
        review.Rating = rating;
        review.ImagesUrls = imageUrls;
        review.IsUpdated = true;
        review.LastUpdatedDate = DateTime.UtcNow;
        
        var result = reviewRepository.Update(review);
    }
    
    public async Task DeleteReviewAsync(Guid reviewId)
    {
        await reviewRepository.Delete(reviewId);
    }
    
    public async Task LikeReviewAsync(Guid reviewId, string userId)
    {
        var check = await CheckUserLikedByIdAsync(userId);
        
        if (check)
            await reviewRepository.Like(reviewId);
    }
    
    public async Task<Domain.Entities.Review> GetByIdAsync(Guid reviewId)
    {
        return await reviewRepository.GetById(reviewId);
    }

    public async Task<IEnumerable<Domain.Entities.Review>> GetAllByUserIdAsync(string userId)
    {
        return await reviewRepository.GetAllByUserId(userId);
    }
    
    public async Task<IEnumerable<Domain.Entities.Review>> GetFirstFiveByDateAsync(Guid productId)
    {
        
        return await reviewRepository.GetFirstByDate(5, productId, DateTime.UtcNow);
    }
    
    public async Task<IEnumerable<Domain.Entities.Review>> GetFirstFiveByRatingAsync(Guid productId)
    {
        return await reviewRepository.GetFirstByRating(5, productId, 0, 5);
    }

    public async Task<IEnumerable<Domain.Entities.Review>> GetAllAsync()
    {
        return await reviewRepository.GetAll();
    }

    public async Task<string> UsersLikedAsync()
    {
        return null;
    }
    
    public async Task<bool> CheckUserLikedByIdAsync(string userId)
    {
        return false;
    }
}