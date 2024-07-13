using Microsoft.AspNetCore.Builder;
using ShopDevelop.Data.DataBase;
using Microsoft.Extensions.DependencyInjection;
using ShopDevelop.Data.Models;

namespace ShopDevelop.Data.TRASHER.InsertDb
{
    public class DbObjects
    {
        public static void Initial(IApplicationBuilder applicationBuilder)
        {
            // Подключаем ApplicationDbContext для работы с базой данных.
            /*ApplicationDbContext applicationDbContext;
            using ()
            {
                applicationDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                if (!applicationDbContext.Products.Any())
                {
                    applicationDbContext.Products.AddRange(Products.Select(p => p.Value));
                    *//*applicationDbContext.AddRange(
                        new Product
                        {
                            Name = "T-Shirt 1",
                            ShortDescription = "",
                            Seller = "From Russia",
                            ImagePath = "./images/Products/T-Shirts/T-Shirt_1.jpg",
                            Price = 3900,
                        }
                    );*//*
                }
            }*/

            ApplicationDbContext context;
            using (var scope = applicationBuilder.ApplicationServices.CreateScope())
            {
                context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                context.SaveChanges();
            }
        }

        public static Dictionary<string, Product> products;
        public static Dictionary<string, Product> Products
        {
            get
            {
                if (products == null)
                {
                    var list = new Product[]
                    {
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
                        },
                    };

                    products = new Dictionary<string, Product>();
                    foreach (var product in list)
                    {
                        products.Add(product.Name, product);
                    }
                }
                return products;
            }
        }
    }
}
