using AutoMapper;
using RenStore.Application.Entities.Category.Queries.GetCategoryById;

namespace RenStore.Application.Data.Common.Mappings.Category;

public class GetCategoryByIdMappingProfile : Profile
{
    public GetCategoryByIdMappingProfile()
    {
        CreateMap<RenStore.Domain.Entities.Category, CategoryByIdVm>();
    }
}