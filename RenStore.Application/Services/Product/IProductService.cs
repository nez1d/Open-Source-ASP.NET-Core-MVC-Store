
namespace RenStore.Application.Services.Product;

public interface IProductService
{
    /// <summary>
    /// Adding new product in database.
    /// </summary>
    /// <param name="product">New product entity.</param>
    /// <param name="sellerId">Seller Id.</param>
    /// <param name="categoryName">Category name.</param>
    /// <returns></returns>
    /*Task<bool> AddNewProductAsync(Domain.Entities.Product product, string categoryName, Guid sellerId);*/
    /// <summary>
    /// Edit exist product on database.
    /// </summary>
    /// <param name="product">Exist a product entity.</param>
    /// <returns>Return true if result is success.</returns>
    /*Task EditProductAsync(Domain.Entities.Product product);

    /// <summary>
    /// Delete product on database.
    /// </summary>
    /// <param name="id">Product id.</param>
    /// <returns>Return true if result is success.</returns>
    Task DeleteProductAsync(Guid id);
    /// <summary>
    /// Get product by unique id.
    /// </summary>
    /// <param name="id">Product id.</param>
    /// <returns>Return product</returns>
    Task<Domain.Entities.Product> GetByIdAsync(Guid? id);
    /// <summary>*/
    /// Calculate product discount by price and old price.
    /// </summary>
    /// <param name="price">Normal price.</param>
    /// <param name="oldPrice">Old price.</param>
    /// <returns>Return...</returns>
    Task<decimal> CalculateDiscountByPriceAsync(decimal price, decimal oldPrice);
    /// <summary>
    /// Calculate product discount by percent.
    /// </summary>
    /// <param name="price">Normal price.</param>
    /// <param name="discountPercent">Percent discount.</param>
    /// <returns>Return new price.</returns>
    /*Task<decimal> CalculateDiscountByPercentAsync(decimal price, decimal discountPercent);
    Task<decimal> RatingCalculateAsync();
    Task<int> ReviewsCalculateAsync();*/
    Task<uint> CreateArticulAsync();
}
