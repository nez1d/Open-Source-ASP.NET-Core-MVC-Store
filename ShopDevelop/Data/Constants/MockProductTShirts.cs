using ShopDevelop.Data.Models;

namespace ShopDevelop.Data.Constants
{
    public class MockProductTShirts
    {
        public IEnumerable<ProductP> Products
        {
            get
            {
                return new List<ProductP>
                {
                    new ProductP
                    {
                        Name = "T-Shirt 1",
                        ShortDescription = "",
                        Seller = "From Russia",
                        ImagePath = "../images/Products/T-Shirts/T-Shirt_1.jpg",
                        Price = 3900,
                    },
                    new ProductP
                    {
                        Name = "T-Shirt 2",
                        ShortDescription = "",
                        Seller = "From Russia",
                        ImagePath = "../images/Products/T-Shirts/T-Shirt_2.jpg",
                        Price = 3900,
                    },
                    new ProductP
                    {
                        Name = "T-Shirt 3",
                        ShortDescription = "",
                        Seller = "From Russia",
                        ImagePath = "../images/Products/T-Shirts/T-Shirt_3.jpg",
                        Price = 3900,
                    },
                    new ProductP
                    {
                        Name = "T-Shirt 4",
                        ShortDescription = "",
                        Seller = "From Russia",
                        ImagePath = "../images/Products/T-Shirts/T-Shirt_4.jpg",
                        Price = 3900,
                    },
                    new ProductP
                    {
                        Name = "T-Shirt 5",
                        ShortDescription = "",
                        Seller = "From Russia",
                        ImagePath = "../images/Products/T-Shirts/T-Shirt_5.jpg",
                        Price = 3900,
                    },
                    new ProductP
                    {
                        Name = "T-Shirt 6",
                        ShortDescription = "",
                        Seller = "From Russia",
                        ImagePath = "../images/Products/T-Shirts/T-Shirt_6.jpg",
                        Price = 3900,
                    },
                    new ProductP
                    {
                        Name = "T-Shirt 7",
                        ShortDescription = "",
                        Seller = "From Russia",
                        ImagePath = "../images/Products/T-Shirts/T-Shirt_7.jpg",
                        Price = 3900,
                    },
                    new ProductP
                    {
                        Name = "T-Shirt 8",
                        ShortDescription = "",
                        Seller = "From Russia",
                        ImagePath = "../images/Products/T-Shirts/T-Shirt_8.jpg",
                        Price = 3900,
                    },
                };
            }
        }

        public ProductP GetObjectProduct(int productId)
        {
            ProductP product = new ProductP();
            return product;
        }
    }
}
