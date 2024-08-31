/*using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ShopDevelop.Data.DataBase;
using ShopDevelop.Data.Models;
using System.Data.Entity;

namespace ShopDevelop.Data.Repository.Entity
{
    public class ShoppingCartRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ShoppingCartRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public string ShoppingCartId { get; set; }

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
                Id = shoppingCartId,
            };
        }
        // Получить все продукты корзины
        public List<ShoppingCartItem> GetAllItems()
        {
            return _applicationDbContext.ShopCartItems
                .Where(i => i.ShoppingCartId == ShoppingCartId)
                .Include(i => i.Product)
                .ToList();
        }
        // Добавить в корзину.
        public bool AddToCart(Product product, int amount)
        {
            if(product.InStock == 0 && amount == 0)
            {
                return false;
            }

            var shoppingCartItem = _applicationDbContext.ShopCartItems.FirstOrDefault(
                c => c.Product.Id == product.Id && c.ShoppingCartId == c.Id);

            if (shoppingCartItem == null) 
            { 
                if(amount > product.InStock)
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
                .Where(c => c.ShoppingCartId == c.Id);
            _applicationDbContext.ShopCartItems.RemoveRange(cartItems);
            _applicationDbContext.SaveChanges();
        }
        // Удалить из корзины.
        public void DeleteToCart(Product product)
        {
            var shoppingCartItem = _applicationDbContext.ShopCartItems.SingleOrDefault(
                s => s.Product.Id == product.Id && s.ShoppingCartId == s.Id);


        }
        // Получить общую стоимость товаров в корзине.
        public decimal GetTotalCartValue()
        {
            return _applicationDbContext.ShopCartItems
                .Where(c => c.ShoppingCartId == c.Id)
                .Select(c => c.Product.Price * c.Amount).Sum();
        }
    }
}
*/