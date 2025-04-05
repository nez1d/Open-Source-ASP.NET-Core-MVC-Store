using MediatR;

namespace ShopDevelop.Application.Entities.ShoppingCart.Command.Remove;

public class RemoveFromCartCommand : IRequest
{
    public Guid ProductId { get; set; }
}