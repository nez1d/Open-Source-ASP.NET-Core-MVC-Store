using MediatR;

namespace ShopDevelop.Application.Entities.ShoppingCart.Command.Remove;

public class RemoveFromCartCommand : IRequest
{
    public Guid ItemId { get; set; }
}