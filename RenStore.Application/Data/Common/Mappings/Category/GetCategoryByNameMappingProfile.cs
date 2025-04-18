using AutoMapper;
using RenStore.Application.Entities.Category.Queries.GetCategoryByName;

namespace RenStore.Application.Data.Common.Mappings.Category;

public class GetCategoryByNameMappingProfile : Profile
{
    public GetCategoryByNameMappingProfile()
    {
        CreateMap<RenStore.Domain.Entities.Category, CategoryByNameVm>();
    }
}