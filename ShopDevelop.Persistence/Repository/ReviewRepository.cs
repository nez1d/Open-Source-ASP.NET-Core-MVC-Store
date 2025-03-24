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
        
    public async Task<Guid> Create(Review review, 
        CancellationToken cancellationToken)
    {
        await context.Reviews.AddAsync(review, cancellationToken);
        await context.SaveChangesAsync();
        return review.Id;    
    }

    public async Task Update(Review review)
    {
        context.Reviews.Update(review);
        await context.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        var review = await GetById(id);     
        if (review == null)
            throw new ArgumentException();
        
        context.Reviews.Remove(review);
        await context.SaveChangesAsync();
    }
    
    public async Task Like(Guid reviewId)
    {
        var review = await GetById(reviewId);
        review.LikesCount += 1;
        
        await Update(review);
    }
    
    public async Task<IEnumerable<Review>> GetAll()
    {
        return await context.Reviews
            .Where(review=> review.Id != null)
            .ToListAsync();
    }

    public async Task<Review> GetById(Guid id)
    {
        return await context.Reviews
            .FirstOrDefaultAsync(review => review.Id == id);
    }

    public async Task<IEnumerable<Review>> GetAllByUserId(string userId)
    {
        return context.Reviews
            .Where(review => review.ApplicationUserId == userId);
    }
    
    public async Task<IEnumerable<Review>> GetFirst(int count, Guid productId)
    {
        return await context.Reviews
            .Where(review => review.ProductId == productId)
            .Take(count)
            .ToListAsync();
    }

    public async Task<IEnumerable<Review>> GetFirstByDateLine(
        int count, 
        Guid productId, 
        DateTime dateStart, 
        DateTime dateEnd)
    {
        return await context.Reviews
            .Where(review => review.ProductId == productId
                && review.CreatedDate.Date.CompareTo(dateStart.Date) >= 0 
                && review.CreatedDate.Date.CompareTo(dateEnd.Date) <= 0)
            .Take(count)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Review>> GetFirstByDate(
        int count, 
        Guid productId, 
        DateTime date)
    {
        return await context.Reviews
            .Where(review => review.ProductId == productId)
            .OrderBy(review => review.CreatedDate.Date)
            .Take(count)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Review>> GetFirstByRating(
        int count, 
        Guid productId)
    {
        return await context.Reviews
            .Where(review => review.ProductId == productId)
            .OrderBy(review => review.Rating)
            .Take(count)
            .ToListAsync();
    }

    public async Task<bool> CheckExistByUserId(Guid productId, string userId)
    {
        try
        {
            var result = await context.Reviews
                .FirstOrDefaultAsync(review => review.ProductId == productId
                    && review.ApplicationUserId == userId);
            if(result == null)
                return true;
        }
        catch { }
        
        return false;
    }
}