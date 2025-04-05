using MediatR;

namespace ShopDevelop.Application.Entities.Review.Queries.GetAllReviewsByUserId;

public class GetAllReviewsByUserIdQuery : IRequest<IList<GetAllReviewsByUserIdVm>>
{
    public string UserId { get; set; }
}