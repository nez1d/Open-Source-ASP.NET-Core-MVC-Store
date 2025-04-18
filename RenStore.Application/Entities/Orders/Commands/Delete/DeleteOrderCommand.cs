using MediatR;

namespace RenStore.Application.Entities.Orders.Commands.Delete;

public class DeleteOrderCommand : IRequest
{
    public Guid OrderId { get; set; }
}