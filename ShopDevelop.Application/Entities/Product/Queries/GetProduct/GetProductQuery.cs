using MediatR;
using ShopDevelop.Application.Entities.Product.Queries.GetProduct;

namespace ShopDevelop.Application.Entities.Product.Queries.GetProductDetails;

public class GetProductQuery : IRequest<ProductVm>
{
    public Guid Id { get; set; }
}