using ShopDevelop.Application.Entities.User.Queries.GetProfile;
using MediatR;
using ShopDevelop.Application.Repository;

namespace ShopDevelop.Persistence.Entities.User.Queries.GetProfile;

public class GetUserProfileHandler(IUserRepository userRepository)
    : IRequestHandler<GetUserProfileQuery, UserProfileLookupDto>
{
    public async Task<UserProfileLookupDto> Handle(
        GetUserProfileQuery request,
        CancellationToken cancellationToken)
    {
        var user = await userRepository.GetUserById(request.Id);

        return new UserProfileLookupDto
        {
            Id = Guid.Parse(user.Id),
            FirstName = user.FirstName,
            Email = user.Email,
            Phone = user.Phone,
            Country = user.Country,
            City = user.City,
            Balance = (double)user.Balance,
            ImagePath = user.ImagePath
        };
    }
}