using AutoMapper;
using ShopDevelop.Domain.Dto.Category;

namespace ShopDevelop.Application.Data.Common.Mappings.Category;

public class CreateCategoryMappingModel : Profile
{
    public CreateCategoryMappingModel()
    {
        CreateMap<CreateCategoryDto, CreateCategoryCommand>();
        CreateMap<CreateCategoryCommand, Domain.Entities.Category>();
    }
}