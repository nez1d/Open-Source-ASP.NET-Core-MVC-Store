using AutoMapper;

namespace ShopDevelop.Application.Data.Common.Mappings.Category;

public class GetCategoryByIdMappingProfile : Profile
{
    public GetCategoryByIdMappingProfile()
    {
        CreateMap<Domain.Entities.Category, CategoryByIdVm>();
    }
}