using ShopDevelop.Application.Repository;
using MediatR;
using ShopDevelop.Application.Entities.User.Queries.GetProfile;
using ShopDevelop.Domain.Models;

namespace ShopDevelop.Application.Services.User;

public class UserService : IUserService
{
    private readonly IUserRepository userRepository;
    private readonly ISender mediator;
    public UserService(IUserRepository userRepository,
        ISender mediator) =>
        (this.mediator, this.userRepository) = 
        (mediator, userRepository);

    public async Task Register(string email, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<string> Login(string email, string password)
    {
        throw new NotImplementedException();
        /*// Получение пользователя.
        var user = await userRepository.GetByLogin();
        // создание токена.
        var token = _jwtProvider.GenerateToken(user);
        //return token.*/
    }

    public async Task<ApplicationUser> FindById(Guid id)
    {
        return await userRepository.GetUserById(id);
    }

    public async Task<UserProfileLookupDto> GetUserProfile(Guid id)
    {
        try
        {
             var user =  await userRepository.GetUserById(id);
             
             return await mediator.Send(new GetUserProfileQuery());
        }
        catch (Exception exception) { }

        return null;
    }

    public async Task RecoverPassword(string email, string password)
    {
        throw new NotImplementedException();
    }

    public async Task RecoverEmail(string email, string password)
    {
        throw new NotImplementedException();
    }
}