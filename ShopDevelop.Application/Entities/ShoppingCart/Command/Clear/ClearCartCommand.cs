using MediatR;

namespace ShopDevelop.Application.Entities.ShoppingCart.Command.Clear;

public class ClearCartCommand : IRequest
{
    public Guid CartId { get; set; }
}