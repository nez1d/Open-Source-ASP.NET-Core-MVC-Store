using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShopDevelop.Application.Entities.Review.Queries.GetFirstByCreatedDate;

namespace ShopDevelop.Persistence.Entities.Review.Queries.GetFirstByCreatedDate;

public class GetFirstReviewsByCreatedDateQueryHandler
    : IRequestHandler<GetFirstReviewsByDateQuery, IList<GetFirstReviewsByDateVm>>
{
    private ILogger<GetFirstReviewsByCreatedDateQueryHandler> logger;
    private readonly ApplicationDbContext context;

    public GetFirstReviewsByCreatedDateQueryHandler(
        ILogger<GetFirstReviewsByCreatedDateQueryHandler> logger,
        ApplicationDbContext context)
    {
        this.logger = logger;
        this.context = context;
    }
    
    public async Task<IList<GetFirstReviewsByDateVm>> Handle(GetFirstReviewsByDateQuery request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Handling {nameof(GetFirstReviewsByCreatedDateQueryHandler)}");
        
        var result = await context.Reviews
            .Where(review => review.ProductId == request.ProductId)
            .OrderBy(review => review.CreatedDate)
            .Select(review => 
                new GetFirstReviewsByDateVm(
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
        
        logger.LogInformation($"Handled {nameof(GetFirstReviewsByCreatedDateQueryHandler)}");

        return result;
    }
}