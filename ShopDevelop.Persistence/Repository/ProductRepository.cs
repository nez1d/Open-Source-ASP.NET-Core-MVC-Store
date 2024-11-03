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
        throw new NotImplementedException();
    }

    public async Task<Guid> Update(Product product)
    {
        throw new NotImplementedException();
    }

    public async Task Delete(Guid id)
    {
        /*var product = GetById(id);
        if (product == null)
            throw new ArgumentException();
        await context.Products.Remove(product);
        await context.SaveChangesAsync();*/
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

    public IEnumerable<Product> GetByCategory(Guid categoryId)
    {
        /*return GetAll().Where(product => product.Category.Id == categoryId);*/
        throw new NotImplementedException();
    }
}