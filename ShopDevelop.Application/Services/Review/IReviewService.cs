namespace ShopDevelop.Application.Services.Review;

public interface IReviewService
{
    Task<bool> CreateReviewAsync(string userId, Guid productId, string text, uint rating, List<string> imagesUrls);
    Task UpdateReviewAsync(Guid reviewId, string text, uint rating, List<string> imageUrls);
    Task DeleteReviewAsync(Guid reviewId);
    Task LikeReviewAsync(Guid reviewId, string userId);
    Task<Domain.Models.Review> GetByIdAsync(Guid reviewId);
    Task<IEnumerable<Domain.Models.Review>> GetAllByUserIdAsync(string userId);
    Task<IEnumerable<Domain.Models.Review>> GetFirstFiveByDateAsync(Guid productId);
    Task<IEnumerable<Domain.Models.Review>> GetFirstFiveByRatingAsync(Guid productId);
    Task<IEnumerable<Domain.Models.Review>> GetAllAsync();
    Task<string> UsersLikedAsync();
    Task<bool> CheckUserLikedByIdAsync(string userId);
}