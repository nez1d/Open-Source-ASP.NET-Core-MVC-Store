/*using Microsoft.EntityFrameworkCore;
using ShopDevelop.Application.Interfaces;
using ShopDevelop.Application.Repository;
using ShopDevelop.Domain.Models;

namespace ShopDevelop.Persistence.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly IApplicationDbContext context;
    public OrderRepository(IApplicationDbContext context) =>
        this.context = context;

    public async Task<Guid> Create(Order order)
    {
        await context.Orders.AddAsync(order);
        await context.SaveChangesAsync();
        return order.Id;    
    }

    public async Task Update(Order order)
    {
        context.Orders.Update(order);
        await context.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
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
}*/