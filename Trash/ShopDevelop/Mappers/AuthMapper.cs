using ShopDevelop.Data.Models;
using ShopDevelop.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace ShopDevelop.Web.Mappers
{
    public class AuthMapper
    {
        public static UserM MapRegisterModelToUserModel(RegisterModelView model)
        {
            return new UserM()
            {
                Email = model.Email!,
                Password = model.Password!,
                Login = model.Login!,
            };
        }
    }
}
