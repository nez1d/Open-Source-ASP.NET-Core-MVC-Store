using ShopDevelop.Domain.Models;

namespace ShopDevelop.Application.Repository;

public interface IShoppingCartRepository
{
    /*/// <summary>
    /// Adding a product in the Shopping Cart.
    /// </summary>
    /// <param name="ShoppingCartId">Id of Shopping Cart.</param>
    /// <param name="product">Product.</param>
    /// <param name="amount">Numbers of products.</param>
    /// <returns>Return result of adding to Shopping Cart.</returns>
    Task<bool> AddToCart(Guid ShoppingCartId, Product product, int amount);
    /// <summary>
    /// Remove product from Shopping Cart.
    /// </summary>
    /// <param name="product">Product to removed.</param>
    /// <returns>Return count of the removing.</returns>
    Task<uint> RemoveFromCart(Product product);
    /// <summary>
    /// Clear a Shopping Cart.
    /// </summary>
    /// <param name="ShoppingCartId">Id of Shopping Cart.</param>
    /// <returns></returns>
    Task ClearCart(Guid ShoppingCartId);*/
    /// <summary>
    /// Get all a Shopping Cart Items.
    /// </summary>
    /// <param name="ShoppingCartId">Id of Shopping Cart.</param>
    /// <returns>Return list Shopping Cart Items.</returns>
    Task<IEnumerable<ShoppingCartItem>> GetShoppingCartItems();
    /*/// <summary>
    /// Getting a Shopping Cart total sum value. 
    /// </summary>
    /// <param name="ShoppingCartId">Id of Shopping Cart.</param>
    /// <returns>Return total value.</returns>
    Task<decimal> GetShoppingCartTotal(Guid ShoppingCartId);*/
    
}