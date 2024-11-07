using MediatR;
using ShopDevelop.Application.Entities.User.Queries.GetProfile;
using ShopDevelop.Domain.Interfaces;

namespace ShopDevelop.Persistence.Entities.User.Queries.GetProfile;

public class GetUserProfileHandler(IApplicationDbContext application)
    : IRequestHandler<GetUserProfileQuery, Guid>
{

}