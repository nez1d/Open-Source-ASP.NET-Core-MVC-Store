using ShopDevelop.Data.Models;
using ShopDevelop.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace ShopDevelop.Web.Mappers
{
    public class AuthMapper
    {
        public static User MapRegisterModelToUserModel(RegisterModelView model)
        {
            return new User()
            {
                Email = model.Email!,
                Password = model.Password!,
                Login = model.Login!,
                Phone = model.PhoneNumber!
            };
        }
    }
}
