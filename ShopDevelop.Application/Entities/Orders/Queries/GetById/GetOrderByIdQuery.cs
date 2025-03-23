using MediatR;

namespace ShopDevelop.Application.Entities.Orders.Queries.GetById;

public class GetOrderByIdQuery : IRequest<GetOrderByIdVm>
{
    public Guid Id { get; set; }
}