using ShopDevelop.Data.Models;

namespace ShopDevelop.Web.Data.SamplesPageProduct
{
    public class MockProductLongSample
    {
        public IEnumerable<Product> ProductPage_1
        {
            get
            {
                return new List<Product>
                {
                    new Product
                    {
                        Name = "Лонгслив 2yk оверсайз базовый Setner...",
                        Article = 000000001,
                        Composition = "cotton",
                        Description = "The Longsleeve Carhartt WIP is the perfect choice for those who want comfort, style and quality. Carhartt Longsleeve is suitable for any occasion - from the beach to the street, from the office to the club. The Carhartt work in progress longsleeve has a unisex design, which makes it suitable for men and women. The CARHARTT WIP embroidery on the chest gives this T-shirt a special touch of fashion. It is available in various colors, which allows you to choose a Karhat T-shirt that is right for you. The quality of Carhartt's clothes is impeccable. The Carhartt longsleeve is made of high-quality materials that make it durable and comfortable. You will feel comfortable in this longsleeve Carhart all day long. If you want to add a stylish Carhart longsleeve to your wardrobe that will look fashionable and high-quality, then Carhartt clothes are an excellent choice",
                        Price = 1600,
                        OldPrice = 1900,
                        Discount = 20,
                        ImagePath = "./images/Products/Product/full__image_1.jpg",
                        ImageMiniPath = "./images/Products/Product/mini__image_1.jpg"
                    }
                };
            }
        } 
    }
}
