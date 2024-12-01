namespace ShopDevelop.Data.Repository.Interfaces
{
    public interface IAuthentificateUserRepository
    {
        int? Authentificate(string email, string password);
    }
}
