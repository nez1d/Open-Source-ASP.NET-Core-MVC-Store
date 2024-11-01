/*namespace ShopDevelop.Application.Services.User;

public class UserService
{
    private readonly IUserRepository userRepository;
    public UserService(IUserRepository userRepository) =>
        this.userRepository = userRepository;

    public async Task Register(string email, string passwordHash)
    {
        var user = Create();

        await userRepository.Add(user);

    }

    public async Task<string> Login(string email, string passwordHash)
    {
        // проверить email и пароль.

        // создать токен.

        // сохранить токен в куки.
    }
}
*/