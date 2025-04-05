using MediatR;
using Microsoft.Extensions.Logging;
using ShopDevelop.Application.Data.Common.Exceptions;
using ShopDevelop.Application.Entities.Product.Commands.Update;
using ShopDevelop.Application.Repository;

namespace ShopDevelop.Persistence.Entities.Product.Command.Update;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IProductRepository productRepository;
    private readonly ILogger logger;
    
    public UpdateProductCommandHandler(
        IProductRepository productRepository,
        ILogger<UpdateProductCommand> logger)
    {
        this.productRepository = productRepository;
        this.logger = logger;
    }
    
    public async Task Handle(UpdateProductCommand request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Handling {nameof(UpdateProductCommand)}");

        var product = await productRepository.GetByIdAsync(request.Id, cancellationToken);

        if (product == null)
            throw new NotFoundException(typeof(Domain.Entities.Product), request.Id);
        
        product.ProductName = request.ProductName;
        product.Description = request.Description;
        product.Price = request.Price;

        await productRepository.UpdateAsync(product, cancellationToken);
        
        logger.LogInformation($"Handled {nameof(UpdateProductCommand)}");
    }
}