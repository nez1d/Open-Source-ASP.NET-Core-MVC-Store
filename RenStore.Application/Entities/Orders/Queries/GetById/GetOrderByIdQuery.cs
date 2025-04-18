using MediatR;

namespace RenStore.Application.Entities.Orders.Queries.GetById;

public class GetOrderByIdQuery : IRequest<GetOrderByIdVm>
{
    public Guid Id { get; set; }
}