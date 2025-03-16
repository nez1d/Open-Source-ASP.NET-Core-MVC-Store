using AutoMapper;
using ShopDevelop.Application.Entities.Category.Queries.GetCategoryByName;
using ShopDevelop.Domain.Entities;

namespace ShopDevelop.Application.Data.Common.Mappings;

public class GetCategoryByNameMappingProfile : Profile
{
    public GetCategoryByNameMappingProfile()
    {
        CreateMap<Category, CategoryByNameVm>();
    }
}