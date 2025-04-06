using MediatR;
using Microsoft.Extensions.Logging;
using ShopDevelop.Application.Entities.ShoppingCart.Command.Remove;
using ShopDevelop.Application.Repository;

namespace ShopDevelop.Persistence.Entities.ShoppingCart.Command.Remove;

public class RemoveFromCartCommandHandler 
    : IRequestHandler<RemoveFromCartCommand>
{
    private readonly ILogger logger;
    private readonly IShoppingCartRepository shoppingCartRepository;
    
    public RemoveFromCartCommandHandler(
        ILogger<RemoveFromCartCommandHandler> logger,
        IShoppingCartRepository shoppingCartRepository)
    {
        this.logger = logger;
        this.shoppingCartRepository = shoppingCartRepository;
    }
    
    public async Task Handle(RemoveFromCartCommand request, 
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Handling {nameof(RemoveFromCartCommandHandler)}");
        
        await shoppingCartRepository.RemoveFromCartAsync(request.ItemId, cancellationToken);
        
        logger.LogInformation($"Handled {nameof(RemoveFromCartCommandHandler)}");
    }
}