using ShopDevelop.Domain.Entities;
using ShopDevelop.Domain.Interfaces.Repository;

namespace ShopDevelop.Application.Repository;

public interface IReviewRepository 
{
    // TODO: Сделать модели nullable и проверки на null
    Task<Guid> CreateAsync(Review review, CancellationToken cancellationToken);
    Task UpdateAsync(Review review);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<Review>> GetAllAsync();
    Task<Review> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<Review>> GetAllByUserIdAsync(string userId, CancellationToken cancellationToken);
    Task<IEnumerable<Review>> GetAllByProductIdAsync(Guid userId, CancellationToken cancellationToken);
    Task<IEnumerable<Review>> GetFirstAsync(int count, Guid productId, CancellationToken cancellationToken);
    Task<IEnumerable<Review>> GetFirstByDateLineAsync(int count, Guid productId, DateTime dateStart, DateTime dateEnd, CancellationToken cancellationToken);
    Task<IEnumerable<Review>> GetFirstByDateAsync(int count, Guid productId, CancellationToken cancellationToken);
    Task<IEnumerable<Review>> GetFirstByRatingAsync(int count, Guid productId, CancellationToken cancellationToken);
    Task LikeAsync(Guid reviewId, CancellationToken cancellationToken);
    Task<bool> CheckExistByUserIdAsync(Guid productId, string userId, CancellationToken cancellationToken);
}
