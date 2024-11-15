using ShopDevelop.Application.Repository;

namespace ShopDevelop.Application.Services.User;

public class UserService
{
    private readonly IUserRepository userRepository;
    public UserService(IUserRepository userRepository) =>
        this.userRepository = userRepository;

    public async Task Register(string email, string passwordHash)
    {
        throw new NotImplementedException();
    }

    /*public async Task<string> Login(string email, string passwordHash)
    {
        // Получение пользователя.
        var user = await userRepository.GetByLogin();
        // создание токена.
        var token = _jwtProvider.GenerateToken(user);
        //return token.
    }*/

/*    public async Task<string> Login(string email, string passwordHash)
    {
        // проверить email и пароль.

        // создать токен.

        // сохранить токен в куки.
        throw new NotImplementedException();
    }*/

    public async Task<ShopDevelop.Domain.Models.User> FindById(Guid id)
    {
        return await userRepository.GetUserById(id);
    }
}