using AutoMapper;
using ShopDevelop.Application.Entities.Review.Commands.Create;
using ShopDevelop.Domain.Dto.Review;

namespace ShopDevelop.Application.Data.Common.Mappings.Review;

public class CreateReviewMappingProfile : Profile
{
    public CreateReviewMappingProfile()
    {
        CreateMap<CreateReviewDto, CreateReviewCommand>();
        
        CreateMap<CreateReviewCommand, Domain.Entities.Review>();
    }
}