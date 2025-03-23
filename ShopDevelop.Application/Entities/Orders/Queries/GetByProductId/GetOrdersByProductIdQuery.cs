using MediatR;

namespace ShopDevelop.Application.Entities.Orders.Queries.GetByProductId;

public class GetOrdersByProductIdQuery : IRequest<IList<GetOrdersByProductIdVm>>
{
    public Guid ProductId { get; set; }
}