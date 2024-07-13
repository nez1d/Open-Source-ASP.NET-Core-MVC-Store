using ShopDevelop.Data.Models;

namespace ShopDevelop.Data.Repository.Interfaces
{
    public interface IRepositoryUser
    {
        Task<User> GetUser(string email);
        Task<User> GetUser(int id);
        Task<int> GetUser(User user);
    }
}
