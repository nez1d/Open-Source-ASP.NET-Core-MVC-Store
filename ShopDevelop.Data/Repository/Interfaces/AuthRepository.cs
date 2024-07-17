using Microsoft.EntityFrameworkCore;
using ShopDevelop.Data.DataBase;
using ShopDevelop.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDevelop.Data.Repository.Interfaces
{
    public class AuthRepository : IUserRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public AuthRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        // Получить пользователя по Email.
        public async Task<User> GetUser(string email)
        {
            return await _applicationDbContext.User
                .SingleOrDefaultAsync(x => x.Email == email);
        }
        // Получить пользователя по Id.
        public async Task<User> GetUser(int id)
        {
            return await _applicationDbContext.User
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        /*public async Task<int> GetUsers(User model)
        {
            return await _applicationDbContext.User
                .ToListAsync();
        }*/
    }
}
