using AutoMapper;
using ShopDevelop.Application.Entities.Category.Queries.GetCategoryById;
using ShopDevelop.Domain.Entities;

namespace ShopDevelop.Application.Data.Common.Mappings;

public class GetCategoryByIdMappingProfile : Profile
{
    public GetCategoryByIdMappingProfile()
    {
        CreateMap<Category, CategoryByIdVm>();
    }
}