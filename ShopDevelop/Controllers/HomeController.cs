using Microsoft.AspNetCore.Mvc;
using ShopDevelop.Data.DataBase;
using ShopDevelop.Data.Entity;
using ShopDevelop.Data.Models;
using System.Runtime.CompilerServices;

namespace ShopDevelop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly ICurrentUser _currentUser;

        public HomeController(ApplicationDbContext applicationDbContext, ICurrentUser currentUser)
        {
            _applicationDbContext = applicationDbContext;
            _currentUser = currentUser;
        }

        [HttpGet]
        public ViewResult Index()
        {
            var product = _applicationDbContext.Products.Where(p => p.Price == 3900).ToList();
            return View(product);
        }
    }
}
