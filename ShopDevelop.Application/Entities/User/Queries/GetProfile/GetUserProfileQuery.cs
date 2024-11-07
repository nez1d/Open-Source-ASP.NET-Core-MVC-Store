using MediatR;

namespace ShopDevelop.Application.Entities.User.Queries.GetProfile;

public class GetUserProfileQuery 
    : IRequest<UserProfileLookupDto>
{
    public Guid Id { get; set; }
}