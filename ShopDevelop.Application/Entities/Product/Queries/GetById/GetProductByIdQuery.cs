using MediatR;
using ShopDevelop.Application.Entities.Product.Queries.GetProduct;

namespace ShopDevelop.Application.Entities.Product.Queries.GetProductDetails;

public class GetProductByIdQuery : IRequest<ProductVm>
{
    public Guid Id { get; set; }
}