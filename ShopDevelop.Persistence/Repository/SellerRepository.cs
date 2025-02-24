using Microsoft.EntityFrameworkCore;
using ShopDevelop.Application.Interfaces;
using ShopDevelop.Application.Repository;
using ShopDevelop.Domain.Entities;

namespace ShopDevelop.Persistence.Repository;

public class SellerRepository : ISellerRepository
{
    private readonly IApplicationDbContext context;
    public SellerRepository(IApplicationDbContext context) =>
        this.context = context;

    public async Task<Guid> Create(Seller seller)
    {
        await context.Sellers.AddAsync(seller);
        await context.SaveChangesAsync();
        return Guid.Empty;
    }

    public async Task Update(Seller seller)
    {
        /*var model = await GetById(seller.Id);
        if (model != null)
        {
            context.Sellers.Update(model);
            await context.SaveChangesAsync();
        }*/
    }

    public async Task Delete(Guid id)
    {
        /*var seller = await GetById(id);     
        if (seller == null)
        {
            throw new ArgumentException();
        }
        context.Sellers.Remove(seller);
        await context.SaveChangesAsync()*/;
    }

    public async Task<IEnumerable<Seller>> GetAll()
    {
        return await context.Sellers
            .Where(seller => seller.Id != null)
            .ToListAsync();
    }

    public async Task<Seller> GetById(uint id)
    {
        return await context.Sellers
            .FirstOrDefaultAsync(seller => seller.Id == id);
    }
}