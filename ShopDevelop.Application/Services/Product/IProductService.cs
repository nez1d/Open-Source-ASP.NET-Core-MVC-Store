using ShopDevelop.Application.Entities.Product.Queries.GetMinimizedProducts;

namespace ShopDevelop.Application.Services.Product;

public interface IProductService
{
    
    /// <summary>
    /// Adding new product in database.
    /// </summary>
    /// <param name="product">New product entity.</param>
    /// <returns></returns>
    Task<bool> AddNewProduct(Domain.Models.Product product);
    /// <summary>
    /// Edit exist product on database.
    /// </summary>
    /// <param name="product">Exist a product entity.</param>
    /// <returns>Return true if result is success.</returns>
    Task EditProduct(Domain.Models.Product product);

    /// <summary>
    /// Delete product on database.
    /// </summary>
    /// <param name="id">Product id.</param>
    /// <returns>Return true if result is success.</returns>
    Task DeleteProduct(Guid id);
    /// <summary>
    /// Get all products on database.
    /// </summary>
    /// <returns>Return minimized product entity dto.</returns>
    Task<IEnumerable<MiniProductLookupDto>> GetAllProducts();
    /// <summary>
    /// Get product by unique id.
    /// </summary>
    /// <param name="id">Product id.</param>
    /// <returns>Return product</returns>
    Task<Domain.Models.Product> GetById(Guid? id);
    /// <summary>
    /// Calculate product discount by price and old price.
    /// </summary>
    /// <param name="price">Normal price.</param>
    /// <param name="oldPrice">Old price.</param>
    /// <returns>Return...</returns>
    Task<decimal> CalculateDiscountByPrice(decimal price, decimal oldPrice);
    /// <summary>
    /// Calculate product discount by percent.
    /// </summary>
    /// <param name="price">Normal price.</param>
    /// <param name="discountPercent">Percent discount.</param>
    /// <returns>Return new price.</returns>
    Task<decimal> CalculateDiscountByPercent(decimal price, decimal discountPercent);
    Task<decimal> RatingCalculate();
    Task<int> ReviewsCalculate();
    Task<int> CreateActicule();
}
