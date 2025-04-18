using MediatR;
using RenStore.Application.Entities.Product.Queries.GetById;

namespace RenStore.Application.Entities.Product.Queries.GetProductDetails;

public class GetProductByIdQuery : IRequest<GetProductByIdVm>
{
    public Guid Id { get; set; }
}