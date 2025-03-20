using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShopDevelop.Application.Entities.Review.Queries.GetAllByProductId;

namespace ShopDevelop.Persistence.Entities.Review.Queries.GetAllByProductId;

public class GetAllReviewsByProductIdQueryHandler
    : IRequestHandler<GetAllReviewsByProductIdQuery, IList<GetAllReviewsByProductIdVm>>
{
    private ILogger<GetAllReviewsByProductIdQueryHandler> logger;
    private readonly ApplicationDbContext context;

    public GetAllReviewsByProductIdQueryHandler(
        ILogger<GetAllReviewsByProductIdQueryHandler> logger,
        ApplicationDbContext context)
    {
        this.logger = logger;
        this.context = context;
    }
    
    public async Task<IList<GetAllReviewsByProductIdVm>> Handle(GetAllReviewsByProductIdQuery request, 
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Handling {nameof(GetAllReviewsByProductIdQueryHandler)}");
        
        var result = await context.Reviews
            .Where(review => review.ProductId == request.ProductId)
            .Select(review => 
                new GetAllReviewsByProductIdVm(
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
        
        logger.LogInformation($"Handled {nameof(GetAllReviewsByProductIdQueryHandler)}");

        return result;
    }
}