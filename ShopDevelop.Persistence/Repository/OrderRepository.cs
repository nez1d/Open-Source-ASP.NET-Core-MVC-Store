using Microsoft.EntityFrameworkCore;
using ShopDevelop.Application.Interfaces;
using ShopDevelop.Application.Repository;
using ShopDevelop.Domain.Entities;

namespace ShopDevelop.Persistence.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly IApplicationDbContext context;
    public OrderRepository(IApplicationDbContext context) =>
        this.context = context;

    public async Task<Guid> CreateAsync(Order order, CancellationToken cancellationToken)
    {
        await context.Orders.AddAsync(order, cancellationToken);
        await context.SaveChangesAsync();
        return order.Id;    
    }

    public async Task UpdateAsync(Order order, CancellationToken cancellationToken)
    {
        context.Orders.Update(order);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var order = await GetByIdAsync(id, cancellationToken);     
        if (order == null)
            throw new ArgumentException();
        
        context.Orders.Remove(order);
        await context.SaveChangesAsync();
    }
    
    public async Task<IEnumerable<Order>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await context.Orders
            .ToListAsync(cancellationToken);
    }

    public async Task<Order> GetByIdAsync(Guid id, 
        CancellationToken cancellationToken)
    {
        return await context.Orders
            .FirstOrDefaultAsync(order => order.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<Order>> GetByUserIdAsync(string userId, 
        CancellationToken cancellationToken)
    {
        return context.Orders
            .Where(order => order.ApplicationUserId == userId);
    }
    
    public async Task<IEnumerable<Order>> GetByProductIdAsync(Guid productId, 
        CancellationToken cancellationToken)
    {
        return context.Orders
            .Where(order => order.ProductId == productId);
    }
}