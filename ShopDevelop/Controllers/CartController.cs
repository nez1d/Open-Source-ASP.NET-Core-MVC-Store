using Microsoft.AspNetCore.Mvc;
using ShopDevelop.Data.DataBase;
using ShopDevelop.Data.Models;
using ShopDevelop.Web.Models;

namespace ShopDevelop.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartController(ApplicationDbContext applicationDbContext,
            IHttpContextAccessor httpContextAccessor,
            ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
            _applicationDbContext = applicationDbContext;
            _httpContextAccessor = httpContextAccessor;
        }


        public static ShoppingCart GetCart(IServiceProvider serviceProvider)
        {
            ISession session = serviceProvider.GetRequiredService
                <IHttpContextAccessor>()?.HttpContext.Session;

            byte[] readData;
            _httpContextAccessor.HttpContext.Session.TryGetValue("key", out readData);


            var user = session.Get(".AspNetCore.Cookies-Session");

            var context = serviceProvider
                .GetService<ApplicationDbContext>();

            string cartId = session.GetString(".AspNetCore.Cookies-Session");
            /*?? Guid.NewGuid().ToString();*/

            if (serviceProvider.GetRequiredService
                <IHttpContextAccessor>().HttpContext.Request
                .Cookies.ContainsKey(".AspNetCore.Cookies-Session"))
            {

            }
            else
            {
                throw new Exception();
            }

            session.SetString(".AspNetCore.Cookies-Session", cartId);
            return new ShoppingCart(context) { Id = cartId };
        }


        public IActionResult Index()
        {
            _shoppingCart.GetAllItems();

            var shoppingCartModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
            };
            return View("Index", shoppingCartModel);
        }

        [HttpGet]
        public IActionResult Add(int id, int amount)
        {
            var product = _applicationDbContext.Products
                .FirstOrDefault(p => p.Id == id);

            if (product != null)
            {
                _shoppingCart.AddToCart(product);
            }

            return Redirect("Index");
        }

        public IActionResult Remove(int id)
        {
            var product = _applicationDbContext.Products
                .FirstOrDefault(p => p.Id == id);

            if (product != null)
            {
                _shoppingCart.DeleteToCart(product);
            }
            return RedirectToAction("Index");
        }
    }
}
