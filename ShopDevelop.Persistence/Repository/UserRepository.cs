using Microsoft.EntityFrameworkCore;
using ShopDevelop.Application.Repository;
using ShopDevelop.Domain.Interfaces;
using ShopDevelop.Domain.Models;

namespace ShopDevelop.Persistence.Repository;

public class UserRepository : IUserRepository
{
    private readonly IApplicationDbContext context;
    public UserRepository(IApplicationDbContext context) =>
        this.context = context;

    public async Task<Guid> CreateUser(User user)
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetAllUsers()
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetUserById(Guid id)
    {
        return await context.Users
            .FirstOrDefaultAsync(product => product.Id == id);
    }
}