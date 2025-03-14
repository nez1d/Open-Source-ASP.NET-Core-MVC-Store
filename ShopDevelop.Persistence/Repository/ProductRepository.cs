using Microsoft.EntityFrameworkCore;
using ShopDevelop.Application.Data.Common.Exceptions;
using ShopDevelop.Application.Repository;
using ShopDevelop.Domain.Entities;
using ShopDevelop.Domain.Entities.Products;

namespace ShopDevelop.Persistence.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext context;
    public ProductRepository(ApplicationDbContext context) =>
        this.context = context;

    public async Task<Guid> CreateAsync(Product product, CancellationToken cancellationToken)
    {
        try
        {
            await context.Products.AddAsync(product, cancellationToken);
            
            product.ProductDetailId = product.ProductDetail.Id;

            var validProduct = ProductValidCheckerAsync(product);

            if (validProduct == null)
                return Guid.Empty;
            
            await context.SaveChangesAsync();
        }
        catch (Exception ex) { }
        
        return product.Id;
     }

    public async Task<Product> ProductValidCheckerAsync(Product product)
    {
        if (product.ClothesProduct != null)
        {
            product.ClothesProductId = product.ClothesProduct.Id;
            return product;
        }
        else if (product.ShoesProduct != null)
        {
            product.ShoesProductId = product.ShoesProduct.Id;
            return product;
        }
        return null;
    }

    public async Task UpdateAsync(Product product, CancellationToken cancellationToken)
    {
        var model = await GetByIdAsync(product.Id, cancellationToken);
        if (model == null)
            throw new NotFoundException(typeof(Product), product.Id);
        
        context.Entry<Product>(model).State = EntityState.Detached;
        context.Products.Update(product);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var product = await GetByIdAsync(id, cancellationToken);
        if (product == null)
            throw new NotFoundException(typeof(Product), id);
        
        context.Products.Remove(product);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return context.Products
            .Where(product => product.Id != null)
            .ToList();
    }

    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await context.Products.FirstOrDefaultAsync(product => 
                product.Id == id, cancellationToken)
                ?? throw new NotFoundException(typeof(Product), id);
    }
    
    public async Task<ClothesProduct?> GetClothesByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var product = await context.ClothesProducts.FirstOrDefaultAsync(product => 
                   product.Id == id, cancellationToken)
                   ?? throw new NotFoundException(typeof(ClothesProduct), id);

        product.Product = null;
        return product;
    }
    
    public async Task<ShoesProduct?> GetShoesByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var product = await context.ShoesProducts.FirstOrDefaultAsync(product => 
                          product.Id == id, cancellationToken)
                      ?? throw new NotFoundException(typeof(ShoesProduct), id);
        
        product.Product = null;
        return product;
    }
    
    public async Task<ProductDetail?> GetDetailsByProductIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await context.ProductDetails
            .FirstOrDefaultAsync(details => 
                details.ProductId == id, cancellationToken);
    }

    public async Task<IEnumerable<Product?>> GetByCategoryIdAsync(Guid categoryId)
    {
        /*return context.Products
            .Where(product => product.Category.Id == categoryId);*/
        return null;
    }
}