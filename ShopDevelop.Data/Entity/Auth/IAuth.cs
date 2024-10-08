using ShopDevelop.Data.Models;

namespace ShopDevelop.Data.Entity.Auth
{
    public interface IAuth
    {
        Task<int> CreateUser(UserM user);
    }
}
