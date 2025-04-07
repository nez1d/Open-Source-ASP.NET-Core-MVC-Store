using ShopDevelop.Domain.Entities;

namespace ShopDevelop.Application.Repository;

public interface IShoppingCartRepository
{
    Task AddToCartAsync(ShoppingCartItem shoppingCartItem, CancellationToken cancellationToken);
    Task RemoveFromCartAsync(Guid itemId, CancellationToken cancellationToken);
    Task ClearFromCartAsync(Guid shoppingCartId, CancellationToken cancellationToken);
    Task<IList<ShoppingCartItem>> GetAllItemsAsync(CancellationToken cancellation);
    Task<ShoppingCartItem> GetItemAsync(string userId, Guid productId, CancellationToken cancellationToken);
    Task<IList<ShoppingCartItem>> GetCartByUserIdAsync(string userId, CancellationToken cancellationToken);
    Task<ShoppingCartItem> GetByItemIdAsync(Guid itemId, CancellationToken cancellationToken);
}