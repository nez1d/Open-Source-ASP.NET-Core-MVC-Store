using ShopDevelop.Domain.Models;

namespace ShopDevelop.Application.Repository;

public interface IReviewRepository
{
    /// <summary>
    /// Create new a Review.
    /// </summary>
    /// <param name="review">Review entity.</param>
    /// <returns>Return review Id.</returns>
    Task<Guid> Create(Review review);
    /// <summary>
    /// Update a review.
    /// </summary>
    /// <param name="review">Review entity.</param>
    /// <returns></returns>
    Task Update(Review review);
    /// <summary>
    /// Delete a review.
    /// </summary>
    /// <param name="id">Reviw Id.</param>
    /// <returns></returns>
    Task Delete(Guid id);
    /// <summary>
    /// Get all a reviews.
    /// </summary>
    /// <returns>Return List a Reviews.</returns>
    Task<IEnumerable<Review>> GetAll();

    /// <summary>
    /// Get review by Review Id.
    /// </summary>
    /// <param name="id">Review Id.</param>
    /// <returns>Return Review.</returns>
    Task<Review> GetById(Guid id);

    Task<IEnumerable<Review>> GetAllByUserId(string userId);

    Task<IEnumerable<Review>> GetFirst(int count, Guid productId);

    Task<IEnumerable<Review>> GetFirstByDateLine(int count, Guid productId, DateTime dateStart, DateTime dateEnd);

    Task<IEnumerable<Review>> GetFirstByDate(int count, Guid productId, DateTime date);

    Task<IEnumerable<Review>> GetFirstByRating(int count, Guid productId, uint ratingStart, uint ratingEnd);

    Task Like(Guid reviewId);

    Task<bool> CheckExistByUserId(Guid productId, string userId);
}
