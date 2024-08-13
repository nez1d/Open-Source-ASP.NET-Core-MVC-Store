using ShopDevelop.Data.Models;

namespace ShopDevelop.Data.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUser(string email);
        Task<User> GetUser(int id);
        Task<User> GetUserForLogin(string login);
        Task<int> CreateUser(User user);
    }
}
