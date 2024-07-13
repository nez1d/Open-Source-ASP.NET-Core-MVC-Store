using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDevelop.Data.Models
{
    public class ShoppingCart
    {
        public string Id { get; set; }

        public User User { get; set; }

        public string UserId { get; set; }

        public List<CartProduct> ProductCollection = new List<CartProduct>();

        // Добавление в корзину.
        //TODO: Переделать return true;
        public bool AddToCart(Product product, int quantity) 
        {
            CartProduct cartProduct = ProductCollection
                .Where(p => p.Product.Id == product.Id)
                .FirstOrDefault();

            if (product.InStock == 0 || quantity == 0)
            {
                return false;         
            }

            if (cartProduct != null)
            {
                ProductCollection.Add(new CartProduct
                {
                    Product = product,
                    Quantity = quantity
                });
                return true;
            }
            else
            {
                cartProduct.Quantity += quantity;
                return true;
            }
        }

        // Удалить из корзины.
        public void DeleteToCart(Product product)
        {
            ProductCollection.RemoveAll(p => p.Product.Id == product.Id);
        }

        // Очистить корзину.
        public void ClearCart()
        {
            ProductCollection.Clear();
        }

        // Получить общую стоимость товаров в корзине.
        public decimal ComputeTotalValue()
        {
            return ProductCollection.Sum(e => e.Product.Price * e.Quantity);
        }

        // Получить корзину.
        public void GetCart()
        {
            
        }
    }

    public class CartProduct
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
