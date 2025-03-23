using MediatR;

namespace ShopDevelop.Application.Entities.Orders.Queries.GetByUserId;

public class GetOrdersByUserIdQuery : IRequest<IList<GetOrdersByUserIdVm>>
{
    public Guid UserId { get; set; }
}