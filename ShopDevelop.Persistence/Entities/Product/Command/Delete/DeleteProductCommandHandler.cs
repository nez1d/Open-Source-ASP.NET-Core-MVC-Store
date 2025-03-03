using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ShopDevelop.Application.Entities.Product.Commands.Delete;
using ShopDevelop.Application.Entities.Product.Commands.Update;
using ShopDevelop.Application.Repository;

namespace ShopDevelop.Persistence.Entities.Product.Command.Delete;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IProductRepository productRepository;
    private readonly ILogger logger;
    
    public DeleteProductCommandHandler(
        IProductRepository productRepository,
        ILogger<UpdateProductCommand> logger) => 
            (this.productRepository, this.logger) = 
            (productRepository, logger);
    
    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Handling {nameof(UpdateProductCommand)}");
        
        await productRepository.Delete(request.ProductId, cancellationToken);
        
        logger.LogInformation($"Handled {nameof(UpdateProductCommand)}");
    }
}