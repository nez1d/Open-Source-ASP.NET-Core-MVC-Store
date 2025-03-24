using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ShopDevelop.Application.Data.Common.Exceptions;
using ShopDevelop.Application.Entities.Seller.Command.Update;
using ShopDevelop.Application.Repository;

namespace ShopDevelop.Persistence.Entities.Seller.Command.Update;

public class UpdateSellerCommandHandler 
    : IRequestHandler<UpdateSellerCommand>
{
    private readonly ILogger logger;
    private readonly IMapper mapper;
    private readonly ISellerRepository sellerRepository;

    public UpdateSellerCommandHandler(IMapper mapper,
        ILogger<UpdateSellerCommandHandler> logger,
        ISellerRepository sellerRepository)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.sellerRepository = sellerRepository;
    }

    public async Task Handle(UpdateSellerCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Handling {nameof(UpdateSellerCommandHandler)}");
        
        var seller = await sellerRepository.GetByIdAsync(request.Id, cancellationToken);
        
        if(seller == null)
            throw new NotFoundException(typeof(Domain.Entities.Category), request.Id);
        
        seller.Name = request.Name;
        seller.Description = request.Description;
        seller.ImagePath = request.ImagePath;
        seller.ImageFooterPath = request.ImageFooterPath;

        await sellerRepository.UpdateAsync(seller, cancellationToken);
        
        logger.LogInformation($"Handled {nameof(UpdateSellerCommandHandler)}");
    }
}