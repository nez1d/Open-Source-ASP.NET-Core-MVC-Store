﻿/*using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using ShopDevelop.Application.Interfaces;
using ShopDevelop.Application.Repository;
using ShopDevelop.Domain.Models;

namespace ShopDevelop.Persistence.Repository;

public class UserRepository : IUserRepository
{
    private readonly IApplicationDbContext context;
    private readonly UserManager<ApplicationUser> userManager;
    public UserRepository(IApplicationDbContext context) =>
        (this.context) = (context);

    public async Task<Guid> CreateUser(ApplicationUser user)
    {
        throw new NotImplementedException();
    }

    public async Task<ApplicationUser> GetAllUsers()
    {
        throw new NotImplementedException();
    }

    public async Task<ApplicationUser> GetUserById(Guid id)
    {
        /*return await this.context.Users
            .FirstOrDefaultAsync(user => Guid.Parse(user.Id) == id);#1#
        
        throw new NotImplementedException();
    }
}*/