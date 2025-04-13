using AutoMapper;
using ShopDevelop.Domain.Dto.Category;

namespace ShopDevelop.Application.Data.Common.Mappings.Category;

public class UpdateCategoryMappingProfile: Profile
{
    public UpdateCategoryMappingProfile()
    {
        CreateMap<UpdateCategoryDto, UpdateCategoryCommand>();
    }
}