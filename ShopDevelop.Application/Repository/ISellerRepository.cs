using ShopDevelop.Domain.Models;

namespace ShopDevelop.Application.Repository;

public interface ISellerRepository
{
    /// <summary>
    /// Create a Seller.
    /// </summary>
    /// <param name="seller">Seller Entity.</param>
    /// <returns>Return Seller Id.</returns>
    Task<Guid> Create(Seller seller);
    /// <summary>
    /// Update a Seller.
    /// </summary>
    /// <param name="seller">Seller Entity.</param>
    /// <returns></returns>
    Task Update(Seller seller);
    /// <summary>
    /// Delete a Seller.
    /// </summary>
    /// <param name="id">Seller Id.</param>
    /// <returns></returns>
    Task Delete(Guid id);
    /// <summary>
    /// Get all a Sellers.
    /// </summary>
    /// <returns>Teturn list a sellers.</returns>
    Task<IEnumerable<Seller>> GetAll();
    /// <summary>
    /// Get Seller By Id.
    /// </summary>
    /// <param name="id">Seller Id.</param>
    /// <returns>Return a Seller.</returns>
    Task<Seller> GetById(Guid id);
}