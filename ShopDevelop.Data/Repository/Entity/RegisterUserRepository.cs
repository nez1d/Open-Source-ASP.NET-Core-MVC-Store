using Microsoft.EntityFrameworkCore;
using ShopDevelop.Data.DataBase;
using ShopDevelop.Data.Entity;
using ShopDevelop.Data.Models;
using ShopDevelop.Service.Interfaces;

namespace ShopDevelop.Data.Repository.Entity
{
    public class RegisterUserRepository 
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterUserRepository(ApplicationDbContext applicationDbContext, IPasswordHasher passwordHasher)
        {
            _applicationDbContext = applicationDbContext;
            _passwordHasher = passwordHasher;
        }

        public async Task<bool> RegisterUserByEmail(string login, string password, string email)
        {
            var user = _applicationDbContext.User
                .FirstOrDefault(u => u.Login == login || u.Email == email);

            if (user != null)
            {
                return false;
            }
            else
            {
                var userItem = new User
                {
                    Login = login,
                    Password = _passwordHasher.GeneratePassword(password),
                    Email = email,
                    FirstName = "",
                    LastName = "",
                    Phone = "",
                    Role = "",
                    Country = "",
                    City = "",
                    Balance = 0,
                    IsActive = true,
                    ImagePath = "",
                };
                _applicationDbContext.User.AddAsync(userItem);
                _applicationDbContext.SaveChangesAsync();
                return true;
            }        
        }

        public async Task<bool> RegisterUserByPhone(string login, string password, string phone)
        {
            var userLogin = _applicationDbContext.User
                .SingleOrDefaultAsync(u => u.Login == login);

            var userEmail = _applicationDbContext.User
                .SingleOrDefaultAsync(u => u.Phone == phone);

            if (userLogin.ToString() != login && userEmail.ToString() != phone)
            {
                var user = new User
                {
                    Login = login,
                    Password = password,
                    Email = "",
                    FirstName = "",
                    LastName = "",
                    Phone = phone,
                    Role = "",
                    Country = "",
                    City = "",
                    Balance = 0,
                    IsActive = true,
                    ImagePath = "",
                };

                _applicationDbContext.User.AddAsync(user);
                _applicationDbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
