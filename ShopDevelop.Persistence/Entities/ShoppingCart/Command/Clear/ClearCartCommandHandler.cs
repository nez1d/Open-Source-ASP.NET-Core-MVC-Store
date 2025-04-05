/*using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ShopDevelop.Application.Entities.ShoppingCart.Command.Clear;
using ShopDevelop.Application.Repository;
using ShopDevelop.Persistence.Repository;

namespace ShopDevelop.Persistence.Entities.ShoppingCart.Command.Clear;

public class ClearCartCommandHandler
    : IRequestHandler<ClearCartCommand>
{
    private readonly ILogger logger;
    private readonly IMapper mapper;
    private readonly IProductRepository productRepository;
    private readonly ShoppingCartRepository shoppingCartRepository;
    private readonly ApplicationDbContext context;
    
    public ClearCartCommandHandler(IMapper mapper,
        ILogger<ClearCartCommandHandler> logger,
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
    
    public async Task Handle(ClearCartCommand request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Handling {nameof(ClearCartCommandHandler)}");
        
        
        
        logger.LogInformation($"Handled {nameof(ClearCartCommandHandler)}");
    }
}*/