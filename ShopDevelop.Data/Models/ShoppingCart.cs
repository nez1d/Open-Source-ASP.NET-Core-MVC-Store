using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopDevelop.Data.DataBase;
using System.Net;

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
        public bool AddToCart(Product product)
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
        // Очистить корзину.
        /*public void ClearCart(Product entity)
        {
            var cartItems = _applicationDbContext
                .ShopCartItems
                .Where(c => c.ShoppingCartId == c.Id);
            _applicationDbContext.ShopCartItems.RemoveRange(cartItems);
            _applicationDbContext.SaveChanges();
        }*/
        // Удалить из корзины.
        public void DeleteToCart(Product product)
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