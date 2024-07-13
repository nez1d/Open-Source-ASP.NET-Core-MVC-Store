/*using Microsoft.EntityFrameworkCore;
using ShopDevelop.Data.DataBase;
using Microsoft.AspNetCore.Http;

namespace ShopDevelop.Data.Models
{
    public class ShoppingCart
    {
        private readonly ApplicationDbContext _context;

        public ShoppingCart(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Идентификатор корзины.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Список элементов корзины.
        /// </summary>
        public IEnumerable<ShoppingCartItem> ShoppingCartItems { get; set; }

        /// <summary>
        /// Проверка на присутствие сессии корзины. (Добавлял ли пользователь товары в корзину).
        /// </summary>x
        public static ShoppingCart GetShoppingCart(IServiceProvider serviceProvider)
        {
            string sessionKey = "CartId";
            // Создание новой сессии.
            ISession session = serviceProvider.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = serviceProvider.GetService<ApplicationDbContext>();
            // Устанавливаем значение из сессии. 
            // Если этого значения нету, то создаем его.
            string shoppingCartId = session.GetString(sessionKey) ?? Guid.NewGuid().ToString();

            // Устанавливаем новую сессию.
            session.SetString(sessionKey, shoppingCartId);
            return new ShoppingCart(context) { Id = shoppingCartId };
        }

        public IEnumerable<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                (ShoppingCartItems = _context.ShopCartItems.Where(c => c.ShoppingCartId == Id).Include(s => s.Product));
        }
        /// <summary>
        /// Добавление в корзину.
        /// </summary>
        /// <param name="product">Продукт.</param>
        /// <param name="amount">Колличество.</param>
        /// <returns>Действительное значение.</returns>
        public bool AddToCart(Product product, int amount)
        {
            // Проверка на наличия продукта
            if (product.InStock == 0 || amount == 0)
            {
                return false;
            }

            var shoppingCartItem = _context.ShopCartItems.SingleOrDefault(
                s => s.Product.Id == product.Id && s.ShoppingCartId == Id);

            var isValidAmount = true;

            if (shoppingCartItem == null)
            {
                if (amount > product.InStock)
                {
                    shoppingCartItem = new ShoppingCartItem
                    {
                        ShoppingCartId = Id,
                        Product = product,
                        Amount = Math.Min(product.InStock, amount)
                    };

                    _context.ShopCartItems.Add(shoppingCartItem);
                }
                else
                {
                    if (product.InStock - shoppingCartItem.Amount - amount >= 0)
                    {
                        shoppingCartItem.Amount += amount;
                    }
                    else
                    {
                        shoppingCartItem.Amount += product.InStock - shoppingCartItem.Amount;
                        isValidAmount = false;
                    }
                }
            }
            // Сохранение изменений в базе данных.
            _context.SaveChanges();
            return isValidAmount;
        }

        /// <summary>
        /// Удаление из корзины.
        /// </summary>
        /// <param name="product"></param>
        /// <returns>Возвращает колличество продукта.</returns>
        public int RemoveFromCart(Product product)
        {
            var shoppingCartItem = _context.ShopCartItems.SingleOrDefault(
                s => s.Product.Id == product.Id && s.ShoppingCartId == Id);

            int localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _context.ShopCartItems.Remove(shoppingCartItem);
                }
            }
            _context.SaveChanges();
            return localAmount;
        }

        /// <summary>
        /// Очистка корзины.
        /// </summary>
        public void ClearCart()
        {
            var cartItems = _context.ShopCartItems.Where(c => c.ShoppingCartId == Id)
                .Select(c => c.Product.Price * c.Amount).Sum();
        }
    }
}
*/