using MediatR;
using Microsoft.Extensions.Logging;
using RenStore.Application.Entities.Seller.Command.Delete;
using RenStore.Application.Repository;

namespace RenStore.Persistence.Entities.Seller.Command.Delete;

public class DeleteSellerCommandHandler
    : IRequestHandler<DeleteSellerCommand>
{
    private readonly ISellerRepository sellerRepository;
    private readonly ILogger<DeleteSellerCommandHandler> logger;

    public DeleteSellerCommandHandler(
        ILogger<DeleteSellerCommandHandler> logger,
        ISellerRepository sellerRepository)
    {
        this.logger = logger;
        this.sellerRepository = sellerRepository;
    }
    
    public async Task Handle(DeleteSellerCommand request, 
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Handling {nameof(DeleteSellerCommandHandler)}");

        await sellerRepository.DeleteAsync(request.Id, cancellationToken);
        
        logger.LogInformation($"Handling {nameof(DeleteSellerCommandHandler)}");
    }
}