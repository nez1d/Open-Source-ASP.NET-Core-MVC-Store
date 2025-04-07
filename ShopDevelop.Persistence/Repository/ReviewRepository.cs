using Microsoft.EntityFrameworkCore;
using ShopDevelop.Application.Interfaces;
using ShopDevelop.Application.Repository;
using ShopDevelop.Domain.Entities;

namespace ShopDevelop.Persistence.Repository;

public class ReviewRepository : IReviewRepository
{
    private readonly IApplicationDbContext context;
    public ReviewRepository(IApplicationDbContext context) =>
        this.context = context;
        
    public async Task<Guid> CreateAsync(Review review, 
        CancellationToken cancellationToken)
    {
        await context.Reviews.AddAsync(review, cancellationToken);
        await context.SaveChangesAsync();
        return review.Id;    
    }

    public async Task UpdateAsync(Review review)
    {
        context.Reviews.Update(review);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var review = await GetByIdAsync(id, cancellationToken);     
        if (review == null)
            throw new ArgumentException();
        
        context.Reviews.Remove(review);
        await context.SaveChangesAsync();
    }
    
    public async Task LikeAsync(Guid reviewId, CancellationToken cancellationToken)
    {
        var review = await GetByIdAsync(reviewId, cancellationToken);
        review.LikesCount += 1;
        
        await UpdateAsync(review);
    }
    
    public async Task<IEnumerable<Review>> GetAllAsync()
    {
        return await context.Reviews
            .ToListAsync();
    }

    public async Task<Review> GetByIdAsync(Guid id, 
        CancellationToken cancellationToken)
    {
        return await context.Reviews
            .FirstOrDefaultAsync(review => 
                review.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<Review>> GetAllByUserIdAsync(string userId, 
        CancellationToken cancellationToken)
    {
        return context.Reviews
            .Where(review => review.ApplicationUserId == userId);
    }
    
    public async Task<IEnumerable<Review>> GetAllByProductIdAsync(Guid productId, 
        CancellationToken cancellationToken)
    {
        return context.Reviews
            .Where(review => review.ProductId == productId);
    }
    
    public async Task<IEnumerable<Review>> GetFirstAsync(int count, Guid productId, 
        CancellationToken cancellationToken)
    {
        return await context.Reviews
            .Where(review => review.ProductId == productId)
            .Take(count)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Review>> GetFirstByDateLineAsync(
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
            .ToListAsync(cancellationToken);
    }
    
    public async Task<IEnumerable<Review>> GetFirstByDateAsync(
        int count, 
        Guid productId, 
        CancellationToken cancellationToken)
    {
        return await context.Reviews
            .Where(review => review.ProductId == productId)
            .OrderBy(review => review.CreatedDate.Date)
            .Take(count)
            .ToListAsync(cancellationToken);
    }
    
    public async Task<IEnumerable<Review>> GetFirstByRatingAsync(int count, Guid productId, 
        CancellationToken cancellationToken)
    {
        return await context.Reviews
            .Where(review => review.ProductId == productId)
            .OrderBy(review => review.Rating)
            .Take(count)
            .ToListAsync(cancellationToken);
    }

    public async Task<bool> CheckExistByUserIdAsync(Guid productId, string userId, 
        CancellationToken cancellationToken)
    {
        try
        {
            var result = await context.Reviews
                .FirstOrDefaultAsync(review => 
                    review.ProductId == productId && 
                    review.ApplicationUserId == userId, 
                    cancellationToken);
            
            if(result == null)
                return true;
        }
        catch { }
        
        return false;
    }
}