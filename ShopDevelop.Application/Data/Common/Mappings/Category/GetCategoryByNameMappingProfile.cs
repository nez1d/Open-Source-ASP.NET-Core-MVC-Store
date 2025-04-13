using AutoMapper;

namespace ShopDevelop.Application.Data.Common.Mappings.Category;

public class GetCategoryByNameMappingProfile : Profile
{
    public GetCategoryByNameMappingProfile()
    {
        CreateMap<Domain.Entities.Category, CategoryByNameVm>();
    }
}