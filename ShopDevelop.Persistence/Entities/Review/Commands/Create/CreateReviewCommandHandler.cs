using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ShopDevelop.Application.Entities.Review.Commands.Create;
using ShopDevelop.Application.Repository;
using ShopDevelop.Application.Services.Review;

namespace ShopDevelop.Persistence.Entities.Review.Commands.Create;

public class CreateReviewCommandHandler
    : IRequestHandler<CreateReviewCommand, Guid>
{
    private readonly IMapper mapper;
    private ILogger<CreateReviewCommandHandler> logger;
    private IReviewRepository reviewRepository;
    private IProductRepository productRepository;
    private ReviewService reviewService;

    public CreateReviewCommandHandler(IMapper mapper, 
        ILogger<CreateReviewCommandHandler> logger,
        IReviewRepository reviewRepository,
        IProductRepository productRepository,
        ReviewService reviewService)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.reviewRepository = reviewRepository;
        this.productRepository = productRepository;
        this.reviewService = reviewService;
    }
    
    public async Task<Guid> Handle(CreateReviewCommand request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Handling {nameof(CreateReviewCommandHandler)}");
        
        // TODO: сделать проверку, оставлял ли пользователь отзыв к текущему продукту.
        
        var product = await productRepository.GetByIdAsync(request.ProductId, cancellationToken);
        if (product == null)
            return Guid.Empty;
        
        var review = mapper.Map<Domain.Entities.Review>(request);
        
        review.CreatedDate = DateTime.UtcNow;
        review.LastUpdatedDate = null;
        review.IsUpdated = false;
        
        var result = await reviewRepository.CreateAsync(review, cancellationToken);
        
        logger.LogInformation($"Handled {nameof(CreateReviewCommandHandler)}");
        
        return result;
    }
}