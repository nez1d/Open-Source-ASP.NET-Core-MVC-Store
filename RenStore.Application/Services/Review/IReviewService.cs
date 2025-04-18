namespace RenStore.Application.Services.Review;

public interface IReviewService
{
    Task<bool> CreateReviewAsync(string userId, Guid productId, string text, uint rating, List<string> imagesUrls, CancellationToken cancellationToken);
    Task UpdateReviewAsync(Guid reviewId, string text, uint rating, List<string> imageUrls);
    Task DeleteReviewAsync(Guid reviewId);
    Task LikeReviewAsync(Guid reviewId, string userId);
    Task<RenStore.Domain.Entities.Review> GetByIdAsync(Guid reviewId);
    Task<IEnumerable<RenStore.Domain.Entities.Review>> GetAllByUserIdAsync(string userId);
    Task<IEnumerable<RenStore.Domain.Entities.Review>> GetFirstFiveByDateAsync(Guid productId);
    Task<IEnumerable<RenStore.Domain.Entities.Review>> GetFirstFiveByRatingAsync(Guid productId);
    Task<IEnumerable<RenStore.Domain.Entities.Review>> GetAllAsync();
    Task<string> UsersLikedAsync();
    Task<bool> CheckUserLikedByIdAsync(string userId);
}