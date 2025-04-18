using MediatR;

namespace RenStore.Application.Entities.Orders.Queries.GetAll;

public class GetAllOrdersQuery : IRequest<IList<GetAllOrdersVm>>
{
}