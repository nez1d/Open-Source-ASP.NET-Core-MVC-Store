/*using ShopDevelop.Application.Entities.Product.Queries.GetAllProducts;
using ShopDevelop.Application.Repository;
using ShopDevelop.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using MediatR;

namespace ShopDevelop.Persistence.Entities.Product.Queries.GetAllProducts;

public class GetAllProductsQueryHandler
    : IRequestHandler<GetProductListQuery, ProductListVm>
{
    private readonly IApplicationDbContext applicationDbContext;
    private readonly IMapper mapper;

    private readonly IProductRepository productRepository;
    public GetAllProductsQueryHandler(IApplicationDbContext applicationDbContext,
        IMapper mapper) =>
        (this.applicationDbContext, this.mapper) = (applicationDbContext, mapper);

    public async Task<ProductListVm> Handle(GetProductListQuery query,
        CancellationToken cancellationToken)
    {
        var product = await applicationDbContext.Products
                .Where(post => post.Id == query.Id)
                .ProjectTo<ProductLookuptDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

        return new ProductListVm
        {
            Products =
        };
    }
}*/