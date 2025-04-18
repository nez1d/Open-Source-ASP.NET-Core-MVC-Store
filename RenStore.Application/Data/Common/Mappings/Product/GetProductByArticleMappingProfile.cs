using AutoMapper;
using RenStore.Application.Entities.Product.Queries.GetByArticle;

namespace RenStore.Application.Data.Common.Mappings.Product;

public class GetProductByArticleMappingProfile : Profile
{
    public GetProductByArticleMappingProfile()
    {
        CreateMap<RenStore.Domain.Entities.Product, GetProductByArticleVm>();
    }
}