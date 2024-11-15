using ShopDevelop.Domain.Models;

namespace ShopDevelop.Application.Repository;

public interface IUserRepository
{
    Task<Guid> CreateUser(User user);
    Task<User> GetAllUsers();
    Task<User> GetUserById(Guid id);
}
