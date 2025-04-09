using Microsoft.EntityFrameworkCore;
using ShopDevelop.Application.Data.Common.Exceptions;
using ShopDevelop.Application.Repository;
using ShopDevelop.Domain.Entities;

namespace ShopDevelop.Persistence.Repository;

public class SellerRepository : ISellerRepository
{
    private readonly ApplicationDbContext context;
    public SellerRepository(ApplicationDbContext context) =>
        this.context = context;

    public async Task<int> CreateAsync(Seller seller, CancellationToken cancellationToken)
    {
        await context.Sellers.AddAsync(seller, cancellationToken);
        await context.SaveChangesAsync();
        return seller.Id;
    }

    public async Task UpdateAsync(Seller seller, CancellationToken cancellationToken)
    {
        Seller model = await GetByIdAsync(seller.Id, cancellationToken)
            ?? throw new NotFoundException(typeof(Seller), seller.Id);
        
        context.Sellers.Update(seller);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        Seller seller = await GetByIdAsync(id, cancellationToken)
            ?? throw new NotFoundException(typeof(Seller), id);
        
        context.Sellers.Remove(seller);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Seller>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await context.Sellers
            .ToListAsync(cancellationToken);
    }

    public async Task<Seller> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await context.Sellers
            .FirstOrDefaultAsync(seller => 
                seller.Id == id, 
                cancellationToken)
            ?? throw new NotFoundException(typeof(Seller), id);
    }
    
    public async Task<Seller> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        return await context.Sellers
            .FirstOrDefaultAsync(seller => 
                seller.Name == name, 
                cancellationToken)
            ?? throw new NotFoundException(typeof(Seller), name);
    }
}