using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShopDevelop.Application.Entities.ShoppingCart.Command.Add;
using ShopDevelop.Application.Repository;
using ShopDevelop.Domain.Entities;
using ShopDevelop.Persistence.Repository;
using AutoMapper;
using MediatR;

namespace ShopDevelop.Persistence.Entities.ShoppingCart.Command.Add;

public class AddToCartCommandHandler 
    : IRequestHandler<AddToCartCommand>
{
    private readonly ILogger logger;
    private readonly IMapper mapper;
    private readonly IProductRepository productRepository;
    private readonly ApplicationDbContext context;
    
    public AddToCartCommandHandler(IMapper mapper,
        ILogger<AddToCartCommandHandler> logger,
        IProductRepository productRepository,
        ApplicationDbContext context)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.productRepository = productRepository;
        this.context = context;
    }
    
    public async Task Handle(AddToCartCommand request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Handling {nameof(AddToCartCommandHandler)}");
        
        var product = await productRepository.GetByIdAsync(request.ProductId, cancellationToken);
        
        var shoppingCartItem = await context.ShoppingCartItems
            .SingleOrDefaultAsync(item => 
                item.Product.Id == product.Id,
                cancellationToken);
        
        var isValidAmount = true;

        if (shoppingCartItem == null)
        {
            if(request.Amount > product.InStock)
                isValidAmount = false;
            
            shoppingCartItem = new ShoppingCartItem()
            {
                Product = product,
                Amount = (uint)Math.Min(product.InStock, request.Amount),
                ApplicationUserId = request.UserId
            };
        }
        else
        {
            if(product.InStock - shoppingCartItem.Amount - request.Amount >= 0)
                shoppingCartItem.Amount += (uint)request.Amount;
            else
            {
                shoppingCartItem.Amount += (product.InStock - shoppingCartItem.Amount);
                isValidAmount = false;
            }
        }
        await context.ShoppingCartItems.AddAsync(shoppingCartItem);
        await context.SaveChangesAsync();
        
        logger.LogInformation($"Handled {nameof(AddToCartCommandHandler)}");
    }
}