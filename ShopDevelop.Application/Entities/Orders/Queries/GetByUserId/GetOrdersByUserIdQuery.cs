using MediatR;

namespace ShopDevelop.Application.Entities.Orders.Queries.GetByUserId;

public class GetOrdersByUserIdQuery : IRequest<IList<GetOrdersByUserIdVm>>
{
    public string UserId { get; set; }
}