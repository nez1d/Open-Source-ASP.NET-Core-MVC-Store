using Microsoft.EntityFrameworkCore;
using ShopDevelop.Application.Repository;
using ShopDevelop.Domain.Interfaces;
using ShopDevelop.Domain.Models;

namespace ShopDevelop.Persistence.Repository;

public class ProductRepository : IProductRepository
{
    private readonly IApplicationDbContext context;
    public ProductRepository(IApplicationDbContext context) =>
        this.context = context;

    public async Task<Guid> Create(Product product)
    {
        await context.Products.AddAsync(product);
        await context.SaveChangesAsync();
        return product.Id;
    }

    public async Task Update(Product product)
    {
        var model = GetById(product.Id);
        if(model!= null)
        {
            context.Products.Update(product);
            await context.SaveChangesAsync();
        }
    }

    public async Task Delete(Guid id)
    {
        var product = await GetById(id);
        if (product == null)
        {
            throw new ArgumentException();
        }
        context.Products.Remove(product);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        return context.Products
            .Where(product => product.Id != null)
            .ToList();
    }

    public async Task<Product?> GetById(Guid? id)
    {
        return await context.Products
            .FirstOrDefaultAsync(product => product.Id == id);
    }

    public IEnumerable<Product> GetByCategoryId(Guid categoryId)
    {
        return context.Products
            .Where(product => product.Category.Id == categoryId);
    }
}