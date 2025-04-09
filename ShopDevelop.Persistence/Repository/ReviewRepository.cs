using Microsoft.EntityFrameworkCore;
using ShopDevelop.Application.Data.Common.Exceptions;
using ShopDevelop.Application.Repository;
using ShopDevelop.Domain.Entities;

namespace ShopDevelop.Persistence.Repository;

public class ReviewRepository : IReviewRepository
{
    private readonly ApplicationDbContext context;
    public ReviewRepository(ApplicationDbContext context) =>
        this.context = context;
        
    public async Task<Guid> CreateAsync(Review review, 
        CancellationToken cancellationToken)
    {
        await context.Reviews.AddAsync(review, cancellationToken);
        await context.SaveChangesAsync();
        return review.Id;    
    }

    public async Task UpdateAsync(Review review, CancellationToken cancellationToken)
    {
        Review result = await GetByIdAsync(review.Id, cancellationToken)
            ?? throw new NotFoundException(typeof(Review), review.Id);
        
        context.Reviews.Update(review);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        Review review = await GetByIdAsync(id, cancellationToken)
            ?? throw new NotFoundException(typeof(Review), id);
        
        context.Reviews.Remove(review);
        await context.SaveChangesAsync();
    }
    
    public async Task<IEnumerable<Review?>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await context.Reviews
            .ToListAsync(cancellationToken)
            ?? throw new NotFoundException(typeof(Review), null);
    }

    public async Task<Review?> GetByIdAsync(Guid id, 
        CancellationToken cancellationToken)
    {
        return await context.Reviews
            .FirstOrDefaultAsync(review => 
                review.Id == id, 
                cancellationToken)
            ?? throw new NotFoundException(typeof(Review), id);
    }

    public async Task<IEnumerable<Review>> GetAllByUserIdAsync(string userId, 
        CancellationToken cancellationToken)
    {
        return await context.Reviews
            .Where(review => review.ApplicationUserId == userId)
            .ToListAsync(cancellationToken)
            ?? throw new NotFoundException(typeof(Review), userId);
    }
    
    public async Task<IEnumerable<Review>> GetAllByProductIdAsync(Guid productId, 
        CancellationToken cancellationToken)
    {
        return context.Reviews
            .Where(review => review.ProductId == productId)
            ?? throw new NotFoundException(typeof(Review), productId);;
    }

    /*public async Task<IEnumerable<Review>> GetFirstByDateLineAsync(
        int count, 
        Guid productId, 
        DateTime dateStart, 
        DateTime dateEnd, 
        CancellationToken cancellationToken)
    {
        return await context.Reviews
            .Where(review => review.ProductId == productId
                && review.CreatedDate.Date.CompareTo(dateStart.Date) >= 0 
                && review.CreatedDate.Date.CompareTo(dateEnd.Date) <= 0)
            .Take(count)
            .ToListAsync(cancellationToken)
            ?? throw new NotFoundException(typeof(Review), productId);
    }*/
    
    public async Task<IEnumerable<Review>> GetFirstByDateAsync(
        int count, 
        Guid productId, 
        CancellationToken cancellationToken)
    {
        return await context.Reviews
            .Where(review => review.ProductId == productId)
            .OrderBy(review => review.CreatedDate.Date)
            .Take(count)
            .ToListAsync(cancellationToken)
            ?? throw new NotFoundException(typeof(Review), productId);
    }
    
    public async Task<IEnumerable<Review>> GetFirstByRatingAsync(int count, Guid productId, 
        CancellationToken cancellationToken)
    {
        return await context.Reviews
            .Where(review => review.ProductId == productId)
            .OrderBy(review => review.Rating)
            .Take(count)
            .ToListAsync(cancellationToken)
            ?? throw new NotFoundException(typeof(Review), productId);
    }

    public async Task<bool> CheckExistByUserIdAsync(Guid productId, string userId, 
        CancellationToken cancellationToken)
    {
        Review result = await context.Reviews
             .FirstOrDefaultAsync(review => 
                 review.ProductId == productId && 
                 review.ApplicationUserId == userId, 
                cancellationToken) 
            ?? throw new NotFoundException(typeof(Review), productId);
            
        return true;
    }
    
    public async Task LikeAsync(Guid reviewId, CancellationToken cancellationToken)
    {
        Review review = await GetByIdAsync(reviewId, cancellationToken);
        review.LikesCount += 1;
        
        await UpdateAsync(review, cancellationToken);
    }
}
