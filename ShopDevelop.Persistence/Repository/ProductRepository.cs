using Microsoft.EntityFrameworkCore;
using ShopDevelop.Application.Data.Common.Exceptions;
using ShopDevelop.Application.Interfaces;
using ShopDevelop.Application.Repository;
using ShopDevelop.Domain.Entities;

namespace ShopDevelop.Persistence.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext context;
    public ProductRepository(ApplicationDbContext context) =>
        this.context = context;

    public async Task<Guid> Create(Product product, CancellationToken cancellationToken)
    {
        try
        {
            await context.Products.AddAsync(product, cancellationToken);
            product.ProductDetailId = product.ProductDetail.Id;
            
            if (product.ClothesProduct.Id != null)
                product.ClothesProductId = product.ClothesProduct.Id;
            else if(product.ClothesProduct.Id != null)
                product.ShoesProductId = product.ShoesProduct.Id;
            
            await context.SaveChangesAsync();
        }
        catch (Exception ex) { }
        
        return product.Id;
     }

    public async Task Update(Product product, CancellationToken cancellationToken)
    {
        var model = await GetById(product.Id, cancellationToken);
        if (model == null)
            throw new NotFoundException(typeof(Product), product.Id);
        
        context.Entry<Product>(model).State = EntityState.Detached;
        context.Products.Update(product);
        await context.SaveChangesAsync();
    }

    public async Task Delete(Guid id, CancellationToken cancellationToken)
    {
        var product = await GetById(id, cancellationToken);
        if (product == null)
            throw new NotFoundException(typeof(Product), id);
        
        context.Products.Remove(product);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        return context.Products
            .Where(product => product.Id != null)
            .ToList();
    }

    public async Task<Product?> GetById(Guid id, CancellationToken cancellationToken)
    {
        return await context.Products
            .FirstOrDefaultAsync(product => 
                product.Id == id, cancellationToken);
    }
    
    public async Task<ProductDetail?> GetDetailsByProductId(Guid id, CancellationToken cancellationToken)
    {
        return await context.ProductDetails
            .FirstOrDefaultAsync(details => 
                details.ProductId == id, cancellationToken);
    }

    public IEnumerable<Product?> GetByCategoryId(Guid categoryId)
    {
        /*return context.Products
            .Where(product => product.Category.Id == categoryId);*/

        return null;
    }
}