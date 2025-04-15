using MediatR;
using ShopDevelop.Application.Entities.Product.Queries.GetById;

namespace ShopDevelop.Application.Entities.Product.Queries.GetProductDetails;

public class GetProductByIdQuery : IRequest<GetProductByIdVm>
{
    public Guid Id { get; set; }
}