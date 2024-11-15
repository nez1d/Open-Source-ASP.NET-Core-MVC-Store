/*using MediatR;
using ShopDevelop.Application.Entities.User.Queries.GetProfile;
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

        if(user != null)
        {
            var userDto = new UserProfileLookupDto
            {
                Id = user.Id,
                Login = user.Login,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Patronymic = user.Patronymic,
                Email = user.Email,
                Phone = user.Phone,
                Country = user.Country,
                City = user.City,
                Balance = user.Balance,
                ImagePath = user.ImagePath,
                ImageFooterPath = user.ImageFooterPath
            };
            return userDto;
        }
        return null;
    }
}*/