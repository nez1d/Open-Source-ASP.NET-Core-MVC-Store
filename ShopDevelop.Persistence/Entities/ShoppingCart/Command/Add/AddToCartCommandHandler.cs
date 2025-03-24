/*using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ShopDevelop.Application.Entities.ShoppingCart.Command.Add;
using ShopDevelop.Application.Repository;
using ShopDevelop.Domain.Entities;
using ShopDevelop.Persistence.Repository;

namespace ShopDevelop.Persistence.Entities.ShoppingCart.Command.Add;

public class AddToCartCommandHandler 
    : IRequestHandler<AddToCartCommand>
{
    private readonly ILogger logger;
    private readonly IMapper mapper;
    private readonly IProductRepository productRepository;
    private readonly ShoppingCartRepository shoppingCartRepository;
    
    public AddToCartCommandHandler(IMapper mapper,
        ILogger<AddToCartCommandHandler> logger,
        IProductRepository productRepository,
        ShoppingCartRepository shoppingCartRepository)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.productRepository = productRepository;
        this.shoppingCartRepository = shoppingCartRepository;
    }
    
    public async Task Handle(AddToCartCommand request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Handling {nameof(AddToCartCommandHandler)}");
        
        /*var product = await productRepository.GetByIdAsync(request.ProductId, cancellationToken);
        
        if(product.InStock == 0 || request.Amount == 0)
            return;

        var cart = await shoppingCart.GetCartAsync();

        var shoppingCartItem = new ShoppingCartItem()
        {
            ShoppingCartId = cart.Id,
            Product = product,
            Amount = (uint)Math.Min(product.InStock, request.Amount),
            ApplicationUserId = request.UserId
        };
        var result = shoppingCartRepository.AddToCartAsync()
        #1#
        
        logger.LogInformation($"Handled {nameof(AddToCartCommandHandler)}");
    }
}*/