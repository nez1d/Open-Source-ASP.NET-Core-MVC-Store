using MediatR;

namespace ShopDevelop.Application.Entities.ShoppingCart.Command.Add;

public class AddToCartCommand : IRequest
{
    public Guid ProductId { get; set; }
    public int Amount { get; set; }
    public Guid UserId { get; set; }
    public Guid CartId { get; set; }
}