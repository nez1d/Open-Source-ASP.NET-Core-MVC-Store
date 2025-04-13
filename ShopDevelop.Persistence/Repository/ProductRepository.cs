using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;
using ShopDevelop.Application.Data.Common.Exceptions;
using ShopDevelop.Application.Repository;
using ShopDevelop.Domain.Entities;
using ShopDevelop.Domain.Entities.Products;

namespace ShopDevelop.Persistence.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext context;
    private readonly string? connectionString;
    
    public ProductRepository(
        ApplicationDbContext context,
        IConfiguration configuration)
    {
        connectionString = configuration.GetConnectionString("DefaultConnection");
        this.context = context;
    }

    public async Task<Guid> CreateAsync(Product product, CancellationToken cancellationToken)
    {
        await context.Products.AddAsync(product, cancellationToken);
            
        product.ProductDetailId = product.ProductDetail.Id;
        
        var validProduct = await ProductValidCheckerAsync(product)
            ?? throw new NotFoundException(typeof(Product), product.Id);;
            
        await context.SaveChangesAsync();
        
        return product.Id;
     }

    private async Task<Product> ProductValidCheckerAsync(Product product)
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
        var model = await GetByIdAsync(product.Id, cancellationToken)
            ?? throw new NotFoundException(typeof(Product), product.Id);
        
        context.Entry<Product>(model).State = EntityState.Detached;
        context.Products.Update(product);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var product = await GetByIdAsync(id, cancellationToken)
            ?? throw new NotFoundException(typeof(Product), id);
        
        context.Products.Remove(product);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken)
    {
        await using var connection = new NpgsqlConnection(connectionString);
        await connection.OpenAsync(cancellationToken);

        const string sql = @"
            SELECT 
                ""Id"", 
                ""ProductName"", 
                ""Price"", 
                ""Rating"", 
                ""ImageMiniPath"", 
                ""SellerName"" 
            FROM 
                ""Products""";

        return await connection
            .QueryAsync<Product>(
                sql, cancellationToken) 
                    ?? [];
    }
    
    public async Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await this.FindByIdAsync(id, cancellationToken)
               ?? throw new NotFoundException(typeof(Product), id);
    }

    public async Task<Product?> FindByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        await using var connection = new NpgsqlConnection(connectionString);
        await connection.OpenAsync(cancellationToken);

        string sql = @"
            SELECT 
                * 
            FROM 
                ""Products""
            WHERE 
                ""Id""=@Id";

        return await connection
           .QueryFirstOrDefaultAsync<Product>(
               sql, new { Id = id })
                   ?? null;
    }
    
    public async Task<ClothesProduct?> GetClothesByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var product = await context.ClothesProducts
            .FirstOrDefaultAsync(product => 
                product.Id == id, 
                cancellationToken)
            ?? throw new NotFoundException(typeof(ClothesProduct), id);

        product.Product = null;
        return product;
    }
    
    public async Task<ShoesProduct?> GetShoesByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var product = await context.ShoesProducts
            .FirstOrDefaultAsync(product => 
                product.Id == id, 
                cancellationToken)
            ?? throw new NotFoundException(typeof(ShoesProduct), id);
        
        product.Product = null;
        return product;
    }

    public async Task<ProductDetail?> GetDetailsByProductIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await this.FindDetailsByProductIdAsync(id, cancellationToken)
               ?? throw new NotFoundException(typeof(ProductDetail), id);
    }
    public async Task<ProductDetail?> FindDetailsByProductIdAsync(Guid id, CancellationToken cancellationToken)
    
    {
        await using var connection = new NpgsqlConnection(connectionString);
        await connection.OpenAsync(cancellationToken);

        const string sql = @"
            SELECT 
                *
            FROM 
                ""ProductDetails""
            WHERE 
                ""Id""=@Id";
        
        return await connection
            .QueryFirstOrDefaultAsync<ProductDetail>(
                sql, new { Id = id })
                    ?? null;
    }

    public async Task<IEnumerable<Product>> GetByCategoryIdAsync(int categoryId, CancellationToken cancellationToken)
    {
        return await this.FindByCategoryIdAsync(categoryId, cancellationToken)
            ?? throw new NotFoundException(typeof(Product), categoryId);
    }

    public async Task<IEnumerable<Product>?> FindByCategoryIdAsync(int categoryId, CancellationToken cancellationToken)
    {
        await using var connection = new NpgsqlConnection(connectionString);
        await connection.OpenAsync(cancellationToken);

        const string sql = @"
            SELECT
                *
            FROM
                ""Products""
            WHERE
                ""CategoryId""=@CategoryId";
        
        return await connection
            .QueryAsync<Product>(
                sql, new
                {
                    CategoryId = categoryId
                })
                    ?? null;
    }
}