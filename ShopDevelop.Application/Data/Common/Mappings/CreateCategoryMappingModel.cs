using AutoMapper;
using ShopDevelop.Application.Entities.Category.Commands.Create;
using ShopDevelop.Domain.Entities;

namespace ShopDevelop.Application.Data.Common.Mappings;

public class CreateCategoryMappingModel : Profile
{
    public CreateCategoryMappingModel()
    {
        CreateMap<CreateCategoryCommand, Category>();
    }
}