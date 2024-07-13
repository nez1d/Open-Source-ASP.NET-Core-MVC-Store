using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ShopDevelop.Data.DataBase;
using ShopDevelop.Data.Models;
using System.Data.Entity;
using System.Collections.Generic;

namespace ShopDevelop.Data.TRASHER
{
    public class SoppingCartRepository
    {
        private readonly ApplicationDbContext _context;

        public SoppingCartRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public List<ShoppingCart> listShopItems { get; set; }

        /*public async Task<List<ShoppingCart>> GetCart()
        {
            return await _context.ShoppingCart
                .OrderBy(c => c.Id)
                .AsNoTracking()
                .ToListAsync();
        }*/

        /*public static ShoppingCart GetCart(IServiceProvider serviceProvider)
        {
            // Создание сессии.
            ISession session = serviceProvider.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;
            var context = serviceProvider.GetService<ApplicationDbContext>();
            string shopCartId = session.GetString("") ?? Guid.NewGuid().ToString();

            session.GetString("CartId", shopCartId);
        }*/

        // Добавление в корзину.
        //TODO: Переделать return true;
        /*public bool AddToCart(Product product, int quantity)
        {
            CartProduct? cartProduct = ProductCollection
                .Where(p => p.Product.Id == product.Id)
                .FirstOrDefault();

            if (product.InStock == 0 || quantity == 0)
            {
                return false;
            }

            if (cartProduct != null)
            {
                ShoppingCartItem.Add(new CartProduct
                {
                    Product = product,
                    Quantity = quantity
                });
                return true;
            }
            else
            {
                cartProduct?.Quantity += quantity;
                return true;
            }
        }*/

        // Удалить из корзины.
        /*public void DeleteToCart(Product product)
        {
            ShoppingCartItem.RemoveAll(p => p.Product.Id == product.Id);
        }*/

        // Очистить корзину.
        /*public void ClearCart()
        {
            ShoppingCartItem.Clear();
        }*/

        // Получить общую стоимость товаров в корзине.
        /*public decimal ComputeTotalValue()
        {
            return ShoppingCartItem.Sum(e => e.Product.Price * e.Quantity);
        }*/

        // Получить корзину.
        public void GetCart()
        {

        }
    }
}
