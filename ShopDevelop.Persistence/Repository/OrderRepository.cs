using Microsoft.EntityFrameworkCore;
using ShopDevelop.Application.Data.Common.Exceptions;
using ShopDevelop.Application.Repository;
using ShopDevelop.Domain.Entities;

namespace ShopDevelop.Persistence.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext context;
    public OrderRepository(ApplicationDbContext context) =>
        this.context = context;

    public async Task<Guid> CreateAsync(Order order, CancellationToken cancellationToken)
    {
        await context.Orders.AddAsync(order, cancellationToken);
        await context.SaveChangesAsync();
        return order.Id;    
    }

    public async Task UpdateAsync(Order order, CancellationToken cancellationToken)
    {
        Order result = await this.GetByIdAsync(order.Id, cancellationToken)
            ?? throw new NotFoundException(typeof(Order), order.Id);
        
        context.Orders.Update(order);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        Order order = await GetByIdAsync(id, cancellationToken)
            ?? throw new NotFoundException(typeof(Order), id);
        
        context.Orders.Remove(order);
        await context.SaveChangesAsync();
    }
    
    public async Task<IEnumerable<Order>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await context.Orders
            .ToListAsync(cancellationToken)
            ?? throw new NotFoundException(typeof(Order), null);
    }

    public async Task<Order> GetByIdAsync(Guid id, 
        CancellationToken cancellationToken)
    {
        return await context.Orders
            .FirstOrDefaultAsync(order => 
                order.Id == id, 
                cancellationToken)
            ?? throw new NotFoundException(typeof(Order), id);
    }

    public async Task<IEnumerable<Order>> GetByUserIdAsync(string userId, 
        CancellationToken cancellationToken)
    {
        return await context.Orders.Where(order => 
                order.ApplicationUserId == userId)
            .ToListAsync(cancellationToken)
            ?? throw new NotFoundException(typeof(Order), userId);
    }
    
    public async Task<IEnumerable<Order>> GetByProductIdAsync(Guid productId, 
        CancellationToken cancellationToken)
    {
        return await context.Orders.Where(order => 
                order.ProductId == productId)
            .ToListAsync(cancellationToken)
            ?? throw new NotFoundException(typeof(Order), productId);
    }
}