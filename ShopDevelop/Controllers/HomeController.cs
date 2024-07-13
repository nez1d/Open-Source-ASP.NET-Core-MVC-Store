using Microsoft.AspNetCore.Mvc;
using ShopDevelop.Data.DataBase;
using ShopDevelop.Data.Models;
using System.Runtime.CompilerServices;

namespace ShopDevelop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public HomeController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        /*public void AddUser()
        {
            var user = new User
            {
                Login = "Admin",
                FirstName = "Max",
                LastName = "Focusov",
                Email = "testmail@gmail.com",
                Phone = "888888888888",
                Password = "qwerty1234",
                Role = "Admin",
                Country = "Russia",
                City = "Moscow",
                Balance = 999,
                IsActive = true,
                ImagePath= "",
                Cart = { },
                CartItems = { }
            };

            _applicationDbContext.User.Add(user);
            _applicationDbContext.SaveChanges();
        }*/

        public ViewResult Index()
        {
            /*AddUser();*/
            var product = _applicationDbContext.Products.Where(p => p.Price == 3900).ToList();
            return View(product);
        }
    }
}
