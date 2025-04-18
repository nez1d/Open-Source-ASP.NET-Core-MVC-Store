using AutoMapper;
using RenStore.Application.Entities.Review.Commands.Create;
using RenStore.Domain.Dto.Review;

namespace RenStore.Application.Data.Common.Mappings.Review;

public class CreateReviewMappingProfile : Profile
{
    public CreateReviewMappingProfile()
    {
        CreateMap<CreateReviewDto, CreateReviewCommand>();
        
        CreateMap<CreateReviewCommand, RenStore.Domain.Entities.Review>();
    }
}