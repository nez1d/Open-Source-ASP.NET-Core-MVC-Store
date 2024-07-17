/*using Microsoft.AspNetCore.Http;
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

        public int Id { get; set; }

        public string ShoppingCartId { get; set; }

        public User User { get; set; }

        public string UserId { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        public IEnumerable<ShoppingCartItem> ShoppingCartItems { get; set; }

        // Получить корзину.
        public static ShoppingCart GetCart(IServiceProvider serviceProvider)
        {
            // Создание объекта для работы с сессиями.
            ISession? session = serviceProvider.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            // Объект для работы с базой данных.
            var context = serviceProvider.GetService<ApplicationDbContext>();
            string shoppingCartId = session.GetString("Id")
                ?? Guid.NewGuid().ToString();
            // Установка новой сессии.
            session.SetString("Id", shoppingCartId);

            return new ShoppingCart(context)
            {
                ShoppingCartId = shoppingCartId
            };
        }
        // Получить все продукты корзины
        public IEnumerable<ShoppingCartItem> GetAllItems()
        {
            return ShoppingCartItems ??
                   (ShoppingCartItems = _applicationDbContext.ShopCartItems
                       .Where(c => c.ShoppingCartId == ShoppingCartId)
                       .Include(s => s.Product));
        }
        // Добавить в корзину.
        public bool AddToCart(Product product, int amount)
        {
            if (product.InStock == 0 && amount == 0)
            {
                return false;
            }

            var shoppingCartItem = _applicationDbContext.ShopCartItems.FirstOrDefault(
                c => c.Product.Id == product.Id && c.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                if (amount > product.InStock)
                {
                    return false;
                }
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Product = product,
                    Amount = amount
                };
                _applicationDbContext.ShopCartItems.Add(shoppingCartItem);
            }
            else
            {
                return false;
            }

            _applicationDbContext.SaveChanges();
            return true;
        }
        // Очистить корзину.
        public void ClearCart(Product entity)
        {
            var cartItems = _applicationDbContext
                .ShopCartItems
                .Where(c => c.ShoppingCartId == ShoppingCartId);
            _applicationDbContext.ShopCartItems.RemoveRange(cartItems);
            _applicationDbContext.SaveChanges();
        }
        // Удалить из корзины.
        public void DeleteToCart(Product product)
        {
            var shoppingCartItem = _applicationDbContext.ShopCartItems.SingleOrDefault(
                s => s.Product.Id == product.Id && s.ShoppingCartId == ShoppingCartId);
        }
        // Получить общую стоимость товаров в корзине.
        public decimal GetTotalCartValue()
        {
            return _applicationDbContext.ShopCartItems
                .Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Product.Price * c.Amount).Sum();
        }
    }
}
*/