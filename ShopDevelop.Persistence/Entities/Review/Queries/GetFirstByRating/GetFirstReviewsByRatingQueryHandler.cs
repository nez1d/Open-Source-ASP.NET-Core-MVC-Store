using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShopDevelop.Application.Entities.Review.Queries.GetFirstByRating;

namespace ShopDevelop.Persistence.Entities.Review.Queries.GetFirstByRating;

public class GetFirstReviewsByRatingQueryHandler
    : IRequestHandler<GetFirstReviewsByRatingQuery, IList<GetFirstReviewsByRatingVm>>
{
    private ILogger<GetFirstReviewsByRatingQueryHandler> logger;
    private readonly ApplicationDbContext context;

    public GetFirstReviewsByRatingQueryHandler(
        ILogger<GetFirstReviewsByRatingQueryHandler> logger,
        ApplicationDbContext context)
    {
        this.logger = logger;
        this.context = context;
    }
    
    public async Task<IList<GetFirstReviewsByRatingVm>> Handle(GetFirstReviewsByRatingQuery request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Handling {nameof(GetFirstReviewsByRatingQueryHandler)}");
        
        var result = await context.Reviews
            .Where(review => review.ProductId == request.ProductId)
            .OrderBy(review => review.Rating)
            .Select(review => 
                new GetFirstReviewsByRatingVm(
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
            .Take(request.Count)
            .ToListAsync(cancellationToken);
        
        logger.LogInformation($"Handled {nameof(GetFirstReviewsByRatingQueryHandler)}");

        return result;
    }
}