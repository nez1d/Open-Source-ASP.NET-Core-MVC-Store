using MediatR;

namespace RenStore.Application.Entities.Product.Queries.GetMinimizedProducts;

public class GetMiniProductListQuery : IRequest<List<ProductMiniLookupDto>> 
{
}