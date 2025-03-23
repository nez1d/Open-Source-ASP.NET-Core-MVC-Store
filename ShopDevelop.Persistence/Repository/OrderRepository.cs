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

    public async Task<Guid> Create(Order order, CancellationToken cancellationToken)
    {
        await context.Orders.AddAsync(order, cancellationToken);
        await context.SaveChangesAsync();
        return order.Id;    
    }

    public async Task Update(Order order, CancellationToken cancellationToken)
    {
        context.Orders.Update(order);
        await context.SaveChangesAsync();
    }

    public async Task Delete(Guid id, CancellationToken cancellationToken)
    {
        var order = await GetById(id);     
        if (order == null)
            throw new ArgumentException();
        
        context.Orders.Remove(order);
        await context.SaveChangesAsync();
    }
    
    public async Task<IEnumerable<Order>> GetAll()
    {
        return await context.Orders
            .Where(order=> order.Id != null)
            .ToListAsync();
    }

    public async Task<Order> GetById(Guid id)
    {
        return await context.Orders
            .FirstOrDefaultAsync(order => order.Id == id);
    }

    public async Task<IEnumerable<Order>> GetByUserId(string userId)
    {
        return context.Orders
            .Where(order => order.ApplicationUserId == userId);
    }
}