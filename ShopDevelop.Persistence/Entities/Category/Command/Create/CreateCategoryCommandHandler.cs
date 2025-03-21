using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ShopDevelop.Application.Entities.Category.Commands.Create;
using ShopDevelop.Application.Repository;

namespace ShopDevelop.Persistence.Entities.Category.Command.Create;

public class CreateCategoryCommandHandler 
    : IRequestHandler<CreateCategoryCommand, int>
{
    private readonly ILogger logger;
    private readonly IMapper mapper;
    private readonly ICategoryRepository categoryRepository;

    public CreateCategoryCommandHandler(IMapper mapper,
        ILogger<CreateCategoryCommandHandler> logger,
        ICategoryRepository categoryRepository)
    {
        this.mapper = mapper;
        this.logger = logger;
        this.categoryRepository = categoryRepository;
    }
    
    public async Task<int> Handle(CreateCategoryCommand request, 
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Handling {nameof(CreateCategoryCommandHandler)}");

        var data = await categoryRepository.GetByNameAsync(request.Name);
        if(data != null)
            return 0;
        
        var category = mapper.Map<Domain.Entities.Category>(request);
        
        var result = await categoryRepository.CreateAsync(category, cancellationToken);
        
        logger.LogInformation($"Handled {nameof(CreateCategoryCommandHandler)}");
        
        return result;
    }
}