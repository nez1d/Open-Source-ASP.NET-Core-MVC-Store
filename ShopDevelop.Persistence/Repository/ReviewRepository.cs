using ShopDevelop.Domain.Interfaces;
using ShopDevelop.Domain.Models;

namespace ShopDevelop.Application.Repository;

public class ReviewRepository 
{
    private readonly IApplicationDbContext context;
    public ReviewRepository(IApplicationDbContext context) =>
        this.context = context;
        
    /*public async Task<Guid> Create(Review review)
    {
        throw new ArgumentNullException();
    }
    Task Update(Review review)
    {

    }
    Task Delete(Guid id)
    {

    }

    Task<IEnumerable<Review>> GetAll()
    {

    }
    Task<Review> GetById(Guid? id)
    {

    }*/
}