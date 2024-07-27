namespace ShopDevelop.Service.Interfaces
{
    public interface IPasswordHasher
    {
        string GeneratePassword(string password);
        bool VerifyPassword(string password, string hashedPassword);
    }
}
