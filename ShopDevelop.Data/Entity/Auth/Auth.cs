using ShopDevelop.Data.Models;
using ShopDevelop.Data.Entity.Auth;
using Microsoft.AspNetCore.Http;

namespace ShopDevelop.Data.Entity.Auth
{
    public class Auth : IAuth 
    {
        private readonly IAuth _auth;
        private readonly IHttpContextAccessor _contextAccessor;

        public Auth(IAuth authDAL,
            IHttpContextAccessor httpContextAccessor)
        {
            _auth = authDAL;
            _contextAccessor = httpContextAccessor;
        }

        public async Task<int> CreateUser(User user)
        {
            /*user.Salt = Guid.NewGuid().ToString();*/
            /*user.Password = _encrypt.HashPassword(user.Password, user.Salt);*/
            int id = await _auth.CreateUser(user);
            return id;
        }

        /*public Task<int> CreateUser(User user)
        {
            throw new NotImplementedException();
        }*/
    }
}
