using MediatR;

namespace ShopDevelop.Application.Entities.Product.Queries.GetMinimizedProducts;

public class GetMiniProductListQuery : IRequest<List<ProductMiniLookupDto>> 
{
}