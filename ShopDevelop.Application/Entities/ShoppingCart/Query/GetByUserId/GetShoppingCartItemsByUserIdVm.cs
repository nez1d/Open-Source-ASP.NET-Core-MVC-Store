using MediatR;

namespace ShopDevelop.Application.Entities.ShoppingCart.Query.GetByUserId;

public class GetShoppingCartItemsByUserIdVm 
{
    public Guid Id { get; set; }
    public uint Amount { get; set; }
    public Guid ProductId { get; set; }
    public string ApplicationUserId { get; set; }

    public GetShoppingCartItemsByUserIdVm(
        Guid id, 
        uint amount, 
        Guid productId, 
        string userId)
    {
        this.Id = id;
        this.Amount = amount;
        this.ProductId = productId;
        this.ApplicationUserId = userId;
    }
}