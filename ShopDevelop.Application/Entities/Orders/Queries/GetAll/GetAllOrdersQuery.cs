using MediatR;

namespace ShopDevelop.Application.Entities.Orders.Queries.GetAll;

public class GetAllOrdersQuery : IRequest<IList<GetAllOrdersVm>>
{
}