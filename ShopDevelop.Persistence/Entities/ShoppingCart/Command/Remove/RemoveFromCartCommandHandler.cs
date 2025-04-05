/*using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShopDevelop.Application.Entities.ShoppingCart.Command.Remove;
using ShopDevelop.Application.Repository;
using ShopDevelop.Persistence.Repository;

namespace ShopDevelop.Persistence.Entities.ShoppingCart.Command.Remove;

public class RemoveFromCartCommandHandler 
    : IRequestHandler<RemoveFromCartCommand>
{
    private readonly ILogger logger;
    private readonly IMapper mapper;
    private readonly IProductRepository productRepository;
    private readonly ShoppingCartRepository shoppingCartRepository;
    private readonly ApplicationDbContext context;
    
    public RemoveFromCartCommandHandler(IMapper mapper,
        ILogger<RemoveFromCartCommandHandler> logger,
        IProductRepository productRepository,
        ShoppingCartRepository shoppingCartRepository,
        ApplicationDbContext context)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.productRepository = productRepository;
        this.shoppingCartRepository = shoppingCartRepository;
        this.context = context;
    }
    
    public async Task Handle(RemoveFromCartCommand request, 
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Handling {nameof(RemoveFromCartCommandHandler)}");
        
        var shoppingCartItem = await context.ShoppingCartItems
            .SingleOrDefaultAsync(s => 
                s.Product.Id == request.ProductId && 
                s.ShoppingCartId == request.CartId);

        if (shoppingCartItem == null)
            return;
        
        context.ShoppingCartItems.Remove(shoppingCartItem);
        await context.SaveChangesAsync();
        
        logger.LogInformation($"Handled {nameof(RemoveFromCartCommandHandler)}");
    }
}*/