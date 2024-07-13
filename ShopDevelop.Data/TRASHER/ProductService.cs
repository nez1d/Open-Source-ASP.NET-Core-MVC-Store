/*using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ShopDevelop.Data.Constants;
using ShopDevelop.Data.DataBase;
using ShopDevelop.Data.Models;

namespace ShopDevelop.Service
{
    public class ProductService
    {
        public static void Initial(IApplicationBuilder app)
        {
            ApplicationDbContext context = null;
            using (var scope = app.ApplicationServices.CreateScope())
            {
                context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            }

            if (!context.Category.Any()) 
            {
                context.Products.AddRange(Products.Select(c => c.Value));
            }

            if (!context.Category.Any())
            {
                context.AddRange(
                new Product
                {
                    Name = "T-Shirt 1",
                    ShortDescription = "",
                    Seller = "From Russia",
                    ImagePath = "./images/Products/T-Shirts/T-Shirt_1.jpg",
                    Price = 3900,
                },
                    new Product
                    {
                        Name = "T-Shirt 2",
                        ShortDescription = "",
                        Seller = "From Russia",
                        ImagePath = "./images/Products/T-Shirts/T-Shirt_2.jpg",
                        Price = 3900,
                    },
                    new Product
                    {
                        Name = "T-Shirt 3",
                        ShortDescription = "",
                        Seller = "From Russia",
                        ImagePath = "./images/Products/T-Shirts/T-Shirt_3.jpg",
                        Price = 3900,
                    },
                    new Product
                    {
                        Name = "T-Shirt 4",
                        ShortDescription = "",
                        Seller = "From Russia",
                        ImagePath = "./images/Products/T-Shirts/T-Shirt_4.jpg",
                        Price = 3900,
                    },
                    new Product
                    {
                        Name = "T-Shirt 5",
                        ShortDescription = "",
                        Seller = "From Russia",
                        ImagePath = "./images/Products/T-Shirts/T-Shirt_5.jpg",
                        Price = 3900,
                    },
                    new Product
                    {
                        Name = "T-Shirt 6",
                        ShortDescription = "",
                        Seller = "From Russia",
                        ImagePath = "./images/Products/T-Shirts/T-Shirt_6.jpg",
                        Price = 3900,
                    },
                    new Product
                    {
                        Name = "T-Shirt 7",
                        ShortDescription = "",
                        Seller = "From Russia",
                        ImagePath = "./images/Products/T-Shirts/T-Shirt_7.jpg",
                        Price = 3900,
                    },
                    new Product
                    {
                        Name = "T-Shirt 8",
                        ShortDescription = "",
                        Seller = "From Russia",
                        ImagePath = "./images/Products/T-Shirts/T-Shirt_8.jpg",
                        Price = 3900,
                    }
                );    
            }
        }

        private static Dictionary<string, Product> product;

        public static Dictionary<string, Product> Products
        {
            get
            {
                if (product == null)
                {
                    var list = new Product[]
                    {
                        new Product { Name = "TShirt 1", Price=2999, }
                    };

                    product = new Dictionary<string, Product>();
                    foreach (var item in list)
                    {
                        product.Add(item.Name, item);
                    }
                }
                return product;
            }
        }
    }
}
*/