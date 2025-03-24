using MediatR;
using ShopDevelop.Domain.Enums;

namespace ShopDevelop.Application.Entities.Orders.Commands.Create;

public class CreateOrderCommand : IRequest<Guid>
{
    public string Address { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public uint Amount { get; set; } 
    public Guid ApplicationUserId { get; set; }
    public Guid ProductId { get; set; }
}