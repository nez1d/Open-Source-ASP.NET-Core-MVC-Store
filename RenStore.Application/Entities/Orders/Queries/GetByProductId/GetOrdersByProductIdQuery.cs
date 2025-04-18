using MediatR;

namespace RenStore.Application.Entities.Orders.Queries.GetByProductId;

public class GetOrdersByProductIdQuery : IRequest<IList<GetOrdersByProductIdVm>>
{
    public Guid ProductId { get; set; }
}