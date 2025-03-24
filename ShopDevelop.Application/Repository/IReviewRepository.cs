using ShopDevelop.Domain.Entities;
using ShopDevelop.Domain.Interfaces.Repository;

namespace ShopDevelop.Application.Repository;

public interface IReviewRepository 
{
    Task<Guid> Create(Review review, CancellationToken cancellationToken);
    Task Update(Review review);
    Task Delete(Guid id);
    Task<IEnumerable<Review>> GetAll();
    Task<Review> GetById(Guid id);
    Task<IEnumerable<Review>> GetAllByUserId(string userId);
    Task<IEnumerable<Review>> GetFirst(int count, Guid productId);
    Task<IEnumerable<Review>> GetFirstByDateLine(int count, Guid productId, DateTime dateStart, DateTime dateEnd);
    Task<IEnumerable<Review>> GetFirstByDate(int count, Guid productId, DateTime date);
    Task<IEnumerable<Review>> GetFirstByRating(int count, Guid productId);
    Task Like(Guid reviewId);
    Task<bool> CheckExistByUserId(Guid productId, string userId);
}
