using MediatR;

namespace ShopDevelop.Application.Entities.ShoppingCart.Query.GetByUserId;

public class GetShoppingCartItemsByUserIdVm 
{
    public Guid Id { get; set; }
    public uint Amount { get; set; }
    public Domain.Entities.Product Product { get; set; }
    public string ApplicationUserId { get; set; }

    public GetShoppingCartItemsByUserIdVm(
        Guid id, 
        uint amount, 
        Domain.Entities.Product product, 
        string userId)
    {
        this.Id = id;
        this.Amount = amount;
        this.Product = product;
        this.ApplicationUserId = userId;
    }
}