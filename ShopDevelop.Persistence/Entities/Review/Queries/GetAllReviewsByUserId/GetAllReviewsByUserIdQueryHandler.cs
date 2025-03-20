using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShopDevelop.Application.Entities.Review.Queries.GetAllReviewsByUserId;

namespace ShopDevelop.Persistence.Entities.Review.Queries.GetAllReviewsByUserId;

public class GetAllReviewsByUserIdQueryHandler 
    : IRequestHandler<GetAllReviewsByUserIdQuery, IList<GetAllReviewsByUserIdVm>>
{
    private ILogger<GetAllReviewsByUserIdQueryHandler> logger;
    private readonly ApplicationDbContext context;

    public GetAllReviewsByUserIdQueryHandler(
        ILogger<GetAllReviewsByUserIdQueryHandler> logger,
        ApplicationDbContext context)
    {
        this.logger = logger;
        this.context = context;
    }
    
    public async Task<IList<GetAllReviewsByUserIdVm>> Handle(GetAllReviewsByUserIdQuery request, 
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Handling {nameof(GetAllReviewsByUserIdQueryHandler)}");
        
        var result = await context.Reviews
            .Where(review => review.ApplicationUserId == request.UserId)
            .Select(review => 
                new GetAllReviewsByUserIdVm(
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
            .ToListAsync(cancellationToken);
        
        logger.LogInformation($"Handled {nameof(GetAllReviewsByUserIdQueryHandler)}");

        return result;
    }
}