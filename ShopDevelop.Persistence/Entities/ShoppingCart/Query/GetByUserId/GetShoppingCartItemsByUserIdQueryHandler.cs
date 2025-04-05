using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShopDevelop.Application.Entities.ShoppingCart.Query.GetByUserId;

namespace ShopDevelop.Persistence.Entities.ShoppingCart.Query.GetByUserId;

public class GetShoppingCartItemsByUserIdQueryHandler 
    : IRequestHandler<GetShoppingCartItemsByUserIdQuery, IList<GetShoppingCartItemsByUserIdVm>>
{
    private readonly ILogger<GetShoppingCartItemsByUserIdQueryHandler> logger;
    private readonly ApplicationDbContext dbContext;

    public GetShoppingCartItemsByUserIdQueryHandler(
        ILogger<GetShoppingCartItemsByUserIdQueryHandler> logger, 
        ApplicationDbContext dbContext)
    {
        this.logger = logger;
        this.dbContext = dbContext;
    }
    
    public async Task<IList<GetShoppingCartItemsByUserIdVm>> Handle(
        GetShoppingCartItemsByUserIdQuery request, 
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Handling {nameof(GetShoppingCartItemsByUserIdQueryHandler)}");
        
        var result = await dbContext.ShoppingCartItems
            .Where(item => item.ApplicationUserId == request.UserId)
            .Select(item => new GetShoppingCartItemsByUserIdVm(
                    item.Id,
                    item.Amount,
                    item.Product,
                    item.ApplicationUserId)
            )
            .ToListAsync(cancellationToken);
        
        logger.LogInformation($"Handled {nameof(GetShoppingCartItemsByUserIdQueryHandler)}");
        
        return result;
    }
}