using ShopDevelop.Data.DataBase;
using ShopDevelop.Data.Repository.Interfaces;

namespace ShopDevelop.Data.Repository.Entity;

public class AuthentificateUserRepository : IAuthentificateUserRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public AuthentificateUserRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public int? Authentificate(string email, string password)
    {
        string encryptPassword = Encrypt(password);

        var user = _applicationDbContext.User.
            SingleOrDefault(u => u.Email == email);

        if (user.Password == encryptPassword)
        {
            return user.Id;
        }
        return null;
    }

    public string Encrypt(string password)
    {
        return password;
    }
}
