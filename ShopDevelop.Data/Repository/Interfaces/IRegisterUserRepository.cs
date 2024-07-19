using ShopDevelop.Data.Models;

namespace ShopDevelop.Data.Repository.Interfaces
{
    public interface IRegisterUserRepository
    {
        public Task<bool> RegisterUserByEmail(string login, string password, string email);
        public Task<bool> RegisterUserByPhone(string login, string password, string phone);
    }
}
