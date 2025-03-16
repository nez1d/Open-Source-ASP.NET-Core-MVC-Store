using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShopDevelop.Application.Entities.Category.Queries.GetAllCategories;

namespace ShopDevelop.Persistence.Entities.Category.Queries.GetAllCategories;

public class GetAllCategoriesQueryHandler
    : IRequestHandler<GetCategoriesListQuery, List<CategoryLookupDto>>
{
    private readonly ILogger<GetAllCategoriesQueryHandler> logger;
    private readonly ApplicationDbContext dbContext;

    public GetAllCategoriesQueryHandler(
        ILogger<GetAllCategoriesQueryHandler> logger,
        ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
        this.logger = logger;
    }
    
    public async Task<List<CategoryLookupDto>> Handle(GetCategoriesListQuery request,
        CancellationToken cancellationToken) 
    {
        logger.LogInformation($"Handling {nameof(GetAllCategoriesQueryHandler)}");
        
        var result = await dbContext.Categories
            .Select(category => 
                new CategoryLookupDto(
                    category.Id,
                    category.Name,
                    category.Description,
                    category.ImagePath)
            ).ToListAsync(cancellationToken);
        
        logger.LogInformation($"Handled {nameof(GetAllCategoriesQueryHandler)}");
        
        return result;
    }
}