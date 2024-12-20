﻿using Microsoft.EntityFrameworkCore;
using ShopDevelop.Data.DataBase;
using ShopDevelop.Data.Models;

namespace ShopDevelop.Data.Repository.Interfaces
{
    public class UserRepository/* : IUserRepository*/
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        // Получить пользователя по Email.
        public async Task<UserM> GetUser(string email)
        {
            return await _applicationDbContext.User
                .SingleOrDefaultAsync(x => x.Email == email);
        }
        // Получить пользователя по Id.
        public async Task<UserM> GetUser(int id)
        {
            return await _applicationDbContext.User
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        // Получить пользователя по Login.
        public async Task<UserM> GetUserForLogin(string login)
        {
            return _applicationDbContext.User
                .FirstOrDefault(x => x.Login == login);
        }

        //TODO: ДОДЕЛАТЬ
        public Task<int> CreateUser(UserM user)
        {
            throw new NotImplementedException();
        }
    }
}