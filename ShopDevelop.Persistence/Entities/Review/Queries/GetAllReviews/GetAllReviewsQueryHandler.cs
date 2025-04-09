using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShopDevelop.Application.Entities.Review.Queries.GetAllReviews;
using ShopDevelop.Application.Repository;
using ShopDevelop.Application.Services.Review;

namespace ShopDevelop.Persistence.Entities.Review.Queries.GetAllReviews;

public class GetAllReviewsQueryHandler 
    : IRequestHandler<GetAllReviewsQuery, IList<GetAllReviewsVm>>
{
    private ILogger<GetAllReviewsQueryHandler> logger;
    private readonly IReviewRepository reviewRepository;

    public GetAllReviewsQueryHandler(
        ILogger<GetAllReviewsQueryHandler> logger,
        IReviewRepository reviewRepository)
    {
        this.logger = logger;
        this.reviewRepository = reviewRepository;
    }
    
    public async Task<IList<GetAllReviewsVm>> Handle(GetAllReviewsQuery request, 
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Handling {nameof(GetAllReviewsQueryHandler)}");

        var items = await reviewRepository.GetAllAsync(cancellationToken);
        
        var result = items
            .Select(review => 
                new GetAllReviewsVm(
                    review.Id,
                    review.CreatedDate,
                    review.LastUpdatedDate,
                    review.IsUpdated,
                    review.Message,
                    review.Rating,
                    review.ImagesUrls,
                    review.LikesCount,
                    review.ApplicationUserId,
                    review.ProductId)
            )
            .ToList();
        
        logger.LogInformation($"Handled {nameof(GetAllReviewsQueryHandler)}");

        return result;
    }
}