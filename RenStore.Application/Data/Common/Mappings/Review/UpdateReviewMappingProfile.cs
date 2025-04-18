using AutoMapper;
using RenStore.Application.Entities.Review.Commands.Update;
using RenStore.Domain.Dto.Review;

namespace RenStore.Application.Data.Common.Mappings.Review;

public class UpdateReviewMappingProfile : Profile
{
    public UpdateReviewMappingProfile()
    {
        CreateMap<UpdateReviewDto, UpdateReviewCommand>();
    }
}