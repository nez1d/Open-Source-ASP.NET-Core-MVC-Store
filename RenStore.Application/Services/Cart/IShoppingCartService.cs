using RenStore.Domain.Entities;

namespace RenStore.Application.Services.Cart;

public interface IShoppingCartService
{
    /// <summary>
    /// Adding a product in the Shopping Cart.
    /// </summary>
    /// <param name="product">Product.</param>
    /// <param name="amount">Numbers of products.</param>
    /// <returns>Return result of adding to Shopping Cart.</returns>
    Task<bool> AddToCart(RenStore.Domain.Entities.Product product, int amount, string userId);
    /// <summary>
    /// Remove product from Shopping Cart.
    /// </summary>
    /// <param name="product">Product to removed.</param>
    /// <returns>Return count of the removing.</returns>
    Task<bool> RemoveFromCart(RenStore.Domain.Entities.Product product);
    /// <summary>
    /// Clear a Shopping Cart.
    /// </summary>
    /// <param name="ShoppingCartId">Id of Shopping Cart.</param>
    /// <returns></returns>
    Task ClearCart(Guid shoppingCartId);
    /// <summary>
    /// Get all a Shopping Cart Items.
    /// </summary>
    /// <param name="ShoppingCartId">Id of Shopping Cart.</param>
    /// <returns>Return list Shopping Cart Items.</returns>
    Task<IEnumerable<ShoppingCartItem>> GetShoppingCartItems();
    /// <summary>
    /// Getting a Shopping Cart total sum value. 
    /// </summary>
    /// <param name="ShoppingCartId">Id of Shopping Cart.</param>
    /// <returns>Return total value.</returns>
    Task<decimal> GetShoppingCartTotal(Guid shoppingCartId);
}
