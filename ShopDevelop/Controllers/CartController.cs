using Microsoft.AspNetCore.Mvc;
using ShopDevelop.Data.Models;
using ShopDevelop.Data.Repository.Entity;
using ShopDevelop.Web.Models;

namespace ShopDevelop.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ShoppingCart _shoppingCart;

        public CartController(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IActionResult Index()
        {
            var products = _shoppingCart.GetAllItems();
            _shoppingCart.ShoppingCartItems = products;

            var shoppingCart = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
            };

            return View("Index", products); 
        }

        /*public IActionResult Add(int id, int? amount = 1)
        {
            var product = _shoppingCart.ShoppingCartItems.FirstOrDefault(x => x.Id == id);

            bool isValidAmount = false;
            if (product != null)
            {
                isValidAmount = _shoppingCart.AddToCart(product, 1);
            }

            return Index();
        }*/
    }
}
