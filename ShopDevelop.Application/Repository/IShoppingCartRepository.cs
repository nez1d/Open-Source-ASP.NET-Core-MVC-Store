/*using ShopDevelop.Domain.Entities;

namespace ShopDevelop.Application.Repository;

public interface IShoppingCartRepository
{
    Task<Guid> CreateShoppingCartAsync(ShoppingCart shoppingCart, CancellationToken cancellationToken);
    Task DeleteShoppingCartAsync(Guid shoppingCartId, CancellationToken cancellationToken);
    Task AddToCartAsync(Guid shoppingCartId, ShoppingCartItem shoppingCartItem, CancellationToken cancellationToken);
    Task RemoveFromCartAsync(Guid itemId, CancellationToken cancellationToken);
    Task ClearFromCartAsync(Guid shoppingCartId, CancellationToken cancellationToken);
    Task<ShoppingCart> GetCartAsync(Guid id, CancellationToken cancellationToken);
    Task<ShoppingCart> GetCartByUserIdAsync(string userId, CancellationToken cancellationToken);
}*/