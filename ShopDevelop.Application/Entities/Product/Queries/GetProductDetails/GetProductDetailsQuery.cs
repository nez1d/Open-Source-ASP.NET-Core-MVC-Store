using MediatR;

namespace ShopDevelop.Application.Entities.Product.Queries.GetProductDetails;

public class GetProductDetailsQuery : IRequest<ProductDetailVm>
{
    public Guid Id { get; set; }
}