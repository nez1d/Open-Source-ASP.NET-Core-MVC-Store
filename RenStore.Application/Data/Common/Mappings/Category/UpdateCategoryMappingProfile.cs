using AutoMapper;
using RenStore.Application.Entities.Category.Commands.Update;
using RenStore.Domain.Dto.Category;

namespace RenStore.Application.Data.Common.Mappings.Category;

public class UpdateCategoryMappingProfile: Profile
{
    public UpdateCategoryMappingProfile()
    {
        CreateMap<UpdateCategoryDto, UpdateCategoryCommand>();
    }
}