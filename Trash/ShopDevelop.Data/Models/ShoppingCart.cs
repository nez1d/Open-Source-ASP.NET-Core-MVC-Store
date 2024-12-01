using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopDevelop.Data.DataBase;

namespace ShopDevelop.Data.Models
{
    public class ShoppingCart
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ShoppingCart(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public string Id { get; set; }

        public IEnumerable<ShoppingCartItem> ShoppingCartItems { get; set; }
        // Получить корзину.
        public static ShoppingCart GetCart(IServiceProvider serviceProvider)
        {
            ISession session = serviceProvider.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = serviceProvider.GetService<ApplicationDbContext>();
            string cartId = session.GetString(".AspNetCore.Cookies-Session") ?? Guid.NewGuid().ToString();

            if (serviceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext.Request
                .Cookies.ContainsKey(".AspNetCore.Cookies-Session"))
            {

            }
            else
            {

            }

            session.SetString(".AspNetCore.Cookies-Session", cartId);
            return new ShoppingCart(context) { Id = cartId };
        }
        // Получить все продукты корзины
        public IEnumerable<ShoppingCartItem> GetAllItems()
        {
            return ShoppingCartItems ??
                   (ShoppingCartItems = _applicationDbContext.ShopCartItems
                        .Where(c => c.ShoppingCartId == Id)
                        .Include(s => s.Product));
        }
        // Добавить в корзину.
        public bool AddToCart(ProductP product)
        {
            if (product.InStock == 0)
            {
                return false;
            }

            var shoppingCartItem = _applicationDbContext.ShopCartItems.SingleOrDefault(
                s => s.Product.Id == product.Id && s.ShoppingCartId == Id);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = Id,
                    Product = product,
                    Amount = 1,
                };
                _applicationDbContext.ShopCartItems.Add(shoppingCartItem);
                _applicationDbContext.SaveChanges();
            }
            else
            {
                return false;
            }


            return true;
        }
        // Удалить из корзины.
        public void DeleteToCart(ProductP product)
        {
            var shoppingCartItem = _applicationDbContext.ShopCartItems.SingleOrDefault(
                s => s.Product.Id == product.Id && s.ShoppingCartId == s.ShoppingCartId);
        }
        // Получить общую стоимость товаров в корзине.
        public decimal? GetTotalCartValue()
        {
            return _applicationDbContext.ShopCartItems
                .Where(c => c.ShoppingCartId == Id)
                .Select(c => c.Product.Price * c.Amount).Sum();
        }
    }
}