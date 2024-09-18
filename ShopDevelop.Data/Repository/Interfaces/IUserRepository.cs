using ShopDevelop.Data.Models;

namespace ShopDevelop.Data.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<UserM> GetUser(string email);
        Task<UserM> GetUser(int id);
        Task<UserM> GetUserForLogin(string login);
        Task<int> CreateUser(UserM user);
    }
}
