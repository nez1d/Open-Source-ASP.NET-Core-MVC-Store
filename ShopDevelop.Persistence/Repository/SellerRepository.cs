using Microsoft.EntityFrameworkCore;
using ShopDevelop.Application.Data.Common.Exceptions;
using ShopDevelop.Application.Interfaces;
using ShopDevelop.Application.Repository;
using ShopDevelop.Domain.Entities;

namespace ShopDevelop.Persistence.Repository;

public class SellerRepository : ISellerRepository
{
    private readonly IApplicationDbContext context;
    public SellerRepository(IApplicationDbContext context) =>
        this.context = context;

    public async Task<int> CreateAsync(Seller seller, CancellationToken cancellationToken)
    {
        await context.Sellers.AddAsync(seller, cancellationToken);
        await context.SaveChangesAsync();
        return seller.Id;
    }

    public async Task UpdateAsync(Seller seller, CancellationToken cancellationToken)
    {
        context.Sellers.Update(seller);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var seller = await GetByIdAsync(id, cancellationToken);     
        if (seller == null)
            return;
        context.Sellers.Remove(seller);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Seller>> GetAllAsync()
    {
        return await context.Sellers
            .ToListAsync();
    }

    public async Task<Seller> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await context.Sellers
            .FirstOrDefaultAsync(seller => seller.Id == id, 
                cancellationToken);
    }
    
    public async Task<Seller> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        return await context.Sellers
            .FirstOrDefaultAsync(seller => seller.Name == name, 
                cancellationToken);
    }
}