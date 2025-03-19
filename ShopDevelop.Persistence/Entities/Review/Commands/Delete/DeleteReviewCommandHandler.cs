using MediatR;
using Microsoft.Extensions.Logging;
using ShopDevelop.Application.Entities.Review.Commands.Delete;
using ShopDevelop.Application.Repository;

namespace ShopDevelop.Persistence.Entities.Review.Commands.Delete;

public class DeleteReviewCommandHandler
    : IRequestHandler<DeleteReviewCommand>
{
    private ILogger<DeleteReviewCommandHandler> logger;
    private IReviewRepository reviewRepository;

    public DeleteReviewCommandHandler(
        ILogger<DeleteReviewCommandHandler> logger,
        IReviewRepository reviewRepository)
    {
        this.logger = logger;
        this.reviewRepository = reviewRepository;
    }
    
    public async Task Handle(DeleteReviewCommand request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Handling {nameof(DeleteReviewCommandHandler)}");
        
        await reviewRepository.Delete(request.Id);
        
        logger.LogInformation($"Handled {nameof(DeleteReviewCommandHandler)}");
    }
}