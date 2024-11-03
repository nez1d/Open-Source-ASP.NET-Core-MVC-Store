using ShopDevelop.Application.Entities.Product.Queries.GetMinimizedProducts;
using Microsoft.EntityFrameworkCore;
using ShopDevelop.Domain.Interfaces;
using MediatR;

namespace ShopDevelop.Persistence.Entities.Product.Queries.GetMinimizedProducts;

public class GetMiniProductListHandler(IApplicationDbContext applicationDbContext)
    : IRequestHandler<GetMiniProductListQuery, 
      List<MiniProductLookupDto>>
{
    public async Task<List<MiniProductLookupDto>> Handle(
        GetMiniProductListQuery query,
        CancellationToken cancellationToken)
    {
        return await applicationDbContext.Products
            .Select(product => new MiniProductLookupDto(
                product.Id, product.ProductName,
                product.Price, product.OldPrice,
                product.Discount, product.Seller,
                product.ImageMiniPath))
            .ToListAsync(cancellationToken: cancellationToken);
    }
}