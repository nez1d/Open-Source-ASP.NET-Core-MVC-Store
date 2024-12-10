using ShopDevelop.Domain.Models;

namespace ShopDevelop.Application.Repository;

public interface IProductRepository
{
    /// <summary>
    /// Create new product.
    /// </summary>
    /// <param name="product">New product entity.</param>
    /// <returns>Return product Id.</returns>
    Task<Guid> Create(Product product);
    /// <summary>
    /// Update a product.
    /// </summary>
    /// <param name="product">Product entity.</param>
    /// <returns></returns>
    Task Update(Product product);
    /// <summary>
    /// Delete a product.
    /// </summary>
    /// <param name="id">Product Id.</param>
    /// <returns></returns>
    Task Delete(Guid id);
    /// <summary>
    /// Get all products.
    /// </summary>
    /// <returns>Retunt List Products.</returns>
    Task<IEnumerable<Product>> GetAll();
    /// <summary>
    /// Get Product by Id.
    /// </summary>
    /// <param name="id">Produt Id.</param>
    /// <returns>Return Product.</returns>
    Task<Product> GetById(Guid? id);
    /// <summary>
    /// Get A product by Category Id.
    /// </summary>
    /// <param name="categoryId">Category Id.</param>
    /// <returns>Return List a Products.</returns>
    IEnumerable<Product> GetByCategoryId(Guid categoryId);
}