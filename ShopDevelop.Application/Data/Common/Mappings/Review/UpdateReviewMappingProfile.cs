using AutoMapper;
using ShopDevelop.Application.Entities.Review.Commands.Update;
using ShopDevelop.Domain.Dto.Review;

namespace ShopDevelop.Application.Data.Common.Mappings.Review;

public class UpdateReviewMappingProfile : Profile
{
    public UpdateReviewMappingProfile()
    {
        CreateMap<UpdateReviewDto, UpdateReviewCommand>();
    }
}