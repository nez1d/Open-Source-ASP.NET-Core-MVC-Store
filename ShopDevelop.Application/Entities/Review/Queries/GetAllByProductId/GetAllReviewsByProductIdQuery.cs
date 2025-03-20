using MediatR;

namespace ShopDevelop.Application.Entities.Review.Queries.GetAllByProductId;

public class GetAllReviewsByProductIdQuery : IRequest<IList<GetAllReviewsByProductIdVm>>
{
    public Guid ProductId { get; set; }
}