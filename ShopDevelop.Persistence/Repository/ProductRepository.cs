using Microsoft.EntityFrameworkCore;
using ShopDevelop.Application.Repository;
using ShopDevelop.Data.Models;
using ShopDevelop.Domain.Models;


namespace ShopDevelop.Persistence.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext context;
    public ProductRepository(ApplicationDbContext context) =>
        this.context = context;

    public async Task<Guid> Create(Product product)
    {
        await context.AddAsync(product);
        await context.SaveChangesAsync();
        return product.Id;
    }

    public async Task<Guid> Update(Product product)
    {
        throw new NotImplementedException();
    }

    public async Task Delete(Guid id)
    {
        var product = GetById(id);
        if (product == null)
            throw new ArgumentException();
        context.Remove(product);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        var data = context.Products
            .Where(product => product.Id != null)
            .ToList();
        return data;
    }

    public async Task<Product> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Product> GetByCategory(Guid categoryId)
    {
        /*return GetAll().Where(product => product.Category.Id == categoryId);*/
        throw new NotImplementedException();
    }
}