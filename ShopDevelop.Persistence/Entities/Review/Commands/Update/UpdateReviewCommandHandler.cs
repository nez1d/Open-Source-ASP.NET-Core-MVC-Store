using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ShopDevelop.Application.Data.Common.Exceptions;
using ShopDevelop.Application.Entities.Review.Commands.Update;
using ShopDevelop.Application.Repository;

namespace ShopDevelop.Persistence.Entities.Review.Commands.Update;

public class UpdateReviewCommandHandler 
    : IRequestHandler<UpdateReviewCommand>
{
    private readonly IMapper mapper;
    private ILogger<UpdateReviewCommandHandler> logger;
    private IReviewRepository reviewRepository;

    public UpdateReviewCommandHandler(IMapper mapper, 
        ILogger<UpdateReviewCommandHandler> logger,
        IReviewRepository reviewRepository)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.reviewRepository = reviewRepository;
    }
    
    public async Task Handle(UpdateReviewCommand request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Handling {nameof(UpdateReviewCommandHandler)}");
        
        var review = await reviewRepository.GetById(request.Id);
        
        if(review.ApplicationUserId != request.ApplicationUserId.ToString())
            throw new NotFoundException(typeof(Domain.Entities.Review), request.ApplicationUserId);
        
        review.LastUpdatedDate = DateTime.UtcNow;
        review.IsUpdated = true;
        review.Message = request.Message;
        review.Rating = request.Rating;
        review.ImagesUrls = request.ImagesUrls;
        
        await reviewRepository.Update(review);
        
        logger.LogInformation($"Handled {nameof(UpdateReviewCommandHandler)}");
    }
}