using ShopDevelop.Domain.Models;

namespace ShopDevelop.Application.Repository;

public interface IUserRepository
{
    Task<Guid> CreateUser(ApplicationUser user);
    Task<ApplicationUser> GetAllUsers();
    Task<ApplicationUser> GetUserById(Guid id);
}
