using MediatR;
using ShopDevelop.Application.Entities.Review.Commands.Update;

namespace ShopDevelop.Persistence.Entities.Review.Commands.Update;

public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand>
{
    // TODO: доделать
    public async Task Handle(UpdateReviewCommand request,
        CancellationToken cancellationToken)
    {
        
    }
}