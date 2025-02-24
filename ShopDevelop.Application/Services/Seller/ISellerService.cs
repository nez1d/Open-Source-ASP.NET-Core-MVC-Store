namespace ShopDevelop.Application.Services.Seller;

public interface ISellerService
{
    /// <summary>
    /// Create a new Seller async.
    /// </summary>
    /// <param name="seller">New Seller Entity.</param>
    /// <returns>Return Seller Id.</returns>
    Task<int> CreateSellerAsync(
        string name, string description,
        string imagePath, string imageFooterPath);
    /// <summary>
    /// Edit a Seller Async.
    /// </summary>
    /// <param name="seller">Seller Entity.</param>
    /// <returns></returns>
    Task EditSellerAsync(Domain.Entities.Seller seller);
    /// <summary>
    /// Delete a Seller Async.
    /// </summary>
    /// <param name="id">Seller id.</param>
    /// <returns></returns>
    Task DeleteSellerAsync(Guid id);
    /// <summary>
    /// Get all Sellers async.
    /// </summary>
    /// <returns>Return a list Sellers async.</returns>
    Task<IEnumerable<Domain.Entities.Seller>> GetAllSellerAsync();
    /// <summary>
    /// Get a Seller by Id async.
    /// </summary>
    /// <param name="id">Seller Id.</param>
    /// <returns>Return Seller.</returns>
    Task<Domain.Entities.Seller> GetSellerByIdAsync(uint id);
}