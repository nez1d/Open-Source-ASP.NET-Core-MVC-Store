using AutoMapper;
using ShopDevelop.Application.Entities.Product.Queries.GetByArticle;

namespace ShopDevelop.Application.Data.Common.Mappings.Product;

public class GetProductByArticleMappingProfile : Profile
{
    public GetProductByArticleMappingProfile()
    {
        CreateMap<Domain.Entities.Product, GetProductByArticleVm>();
    }
}