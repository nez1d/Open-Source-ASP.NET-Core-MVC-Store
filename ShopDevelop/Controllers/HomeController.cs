using Microsoft.AspNetCore.Mvc;
using ShopDevelop.Data.DataBase;
using ShopDevelop.Data.Entity;
using ShopDevelop.Data.Models;
using System.Runtime.CompilerServices;

namespace ShopDevelop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly ICurrentUser _currentUser;

        public HomeController(ApplicationDbContext applicationDbContext, ICurrentUser currentUser)
        {
            _applicationDbContext = applicationDbContext;
            _currentUser = currentUser;
        }

        public void AddProduct()
        {
            

            var product = new List<ProductP>
        {
            new ProductP
            {
                Name = "T-Shirt 1",
                ShortDescription = "",
                Seller = "From Russia",
                ImagePath = "../images/Products/T-Shirts/T-Shirt_1.jpg",
                Price = 3900,

                Article = 000000002,
                Size = "",
                Description = "The Longsleeve Carhartt WIP is the perfect choice for those who want comfort, style and quality. Carhartt Longsleeve is suitable for any occasion - from the beach to the street, from the office to the club. The Carhartt work in progress longsleeve has a unisex design, which makes it suitable for  men and women. The CARHARTT WIP embroidery on the  chest gives this T-shirt a special touch of fashion. It is  available in various colors, which allows you to choose a Karhat T-shirt that is right for you. The quality of Carhartt's clothes is impeccable. The Carhartt longsleeve is made of high-quality materials that make it durable and comfortable.You will feel comfortable in this longsleeve Carhart all day long. If you want to add a stylish Carhart longsleeve to your wardrobe that will look fashionable and high-quality, then Carhartt clothes are an excellent choice",
                Count = 99,
                OldPrice = 1900,
                Discount = 1600,
                Composition = "cotton",
                Rating = 5,
                IsFavorite = true,
                IsAvailable = true,
                InStock = 99,
                CategoryId = 0000001,
                Category = new Category
                {
                    Name = "T-Shirt",
                    Description = "",
                    ImagePath = "",
                },
                ImageMiniPath = "../images/Products/T-Shirts/T-Shirt_1.jpg",
            },
            new ProductP
            {
                Name = "T-Shirt 2",
                ShortDescription = "",
                Seller = "From Russia",
                ImagePath = "../images/Products/T-Shirts/T-Shirt_2.jpg",
                Price = 3900,

                Article = 000000003,
                Size = "",
                Description = "The Longsleeve Carhartt WIP is the perfect choice for those who want comfort, style and quality. Carhartt Longsleeve is suitable for any occasion - from the beach to the street, from the office to the club. The Carhartt work in progress longsleeve has a unisex design, which makes it suitable for  men and women. The CARHARTT WIP embroidery on the  chest gives this T-shirt a special touch of fashion. It is  available in various colors, which allows you to choose a Karhat T-shirt that is right for you. The quality of Carhartt's clothes is impeccable. The Carhartt longsleeve is made of high-quality materials that make it durable and comfortable.You will feel comfortable in this longsleeve Carhart all day long. If you want to add a stylish Carhart longsleeve to your wardrobe that will look fashionable and high-quality, then Carhartt clothes are an excellent choice",
                Count = 99,
                OldPrice = 1900,
                Discount = 1600,
                Composition = "cotton",
                Rating = 5,
                IsFavorite = true,
                IsAvailable = true,
                InStock = 99,
                CategoryId = 0000001,
                Category = new Category
                {
                    Name = "T-Shirt",
                    Description = "",
                    ImagePath = "",
                },
                ImageMiniPath = "../images/Products/T-Shirts/T-Shirt_1.jpg",
            },
            new ProductP
            {
                Name = "T-Shirt 3",
                ShortDescription = "",
                Seller = "From Russia",
                ImagePath = "../images/Products/T-Shirts/T-Shirt_3.jpg",
                Price = 3900,

                Article = 000000004,
                Size = "",
                Description = "The Longsleeve Carhartt WIP is the perfect choice for those who want comfort, style and quality. Carhartt Longsleeve is suitable for any occasion - from the beach to the street, from the office to the club. The Carhartt work in progress longsleeve has a unisex design, which makes it suitable for  men and women. The CARHARTT WIP embroidery on the  chest gives this T-shirt a special touch of fashion. It is  available in various colors, which allows you to choose a Karhat T-shirt that is right for you. The quality of Carhartt's clothes is impeccable. The Carhartt longsleeve is made of high-quality materials that make it durable and comfortable.You will feel comfortable in this longsleeve Carhart all day long. If you want to add a stylish Carhart longsleeve to your wardrobe that will look fashionable and high-quality, then Carhartt clothes are an excellent choice",
                Count = 99,
                OldPrice = 1900,
                Discount = 1600,
                Composition = "cotton",
                Rating = 5,
                IsFavorite = true,
                IsAvailable = true,
                InStock = 99,
                CategoryId = 0000001,
                Category = new Category
                {
                    Name = "T-Shirt",
                    Description = "",
                    ImagePath = "",
                },
                ImageMiniPath = "../images/Products/T-Shirts/T-Shirt_1.jpg",
            },
            new ProductP
            {
                Name = "T-Shirt 4",
                ShortDescription = "",
                Seller = "From Russia",
                ImagePath = "../images/Products/T-Shirts/T-Shirt_4.jpg",
                Price = 3900,

                Article = 000000005,
                Size = "",
                Description = "The Longsleeve Carhartt WIP is the perfect choice for those who want comfort, style and quality. Carhartt Longsleeve is suitable for any occasion - from the beach to the street, from the office to the club. The Carhartt work in progress longsleeve has a unisex design, which makes it suitable for  men and women. The CARHARTT WIP embroidery on the  chest gives this T-shirt a special touch of fashion. It is  available in various colors, which allows you to choose a Karhat T-shirt that is right for you. The quality of Carhartt's clothes is impeccable. The Carhartt longsleeve is made of high-quality materials that make it durable and comfortable.You will feel comfortable in this longsleeve Carhart all day long. If you want to add a stylish Carhart longsleeve to your wardrobe that will look fashionable and high-quality, then Carhartt clothes are an excellent choice",
                Count = 99,
                OldPrice = 1900,
                Discount = 1600,
                Composition = "cotton",
                Rating = 5,
                IsFavorite = true,
                IsAvailable = true,
                InStock = 99,
                CategoryId = 0000001,
                Category = new Category
                {
                    Name = "T-Shirt",
                    Description = "",
                    ImagePath = "",
                },
                ImageMiniPath = "../images/Products/T-Shirts/T-Shirt_1.jpg",
            },
            new ProductP
            {
                Name = "T-Shirt 5",
                ShortDescription = "",
                Seller = "From Russia",
                ImagePath = "../images/Products/T-Shirts/T-Shirt_5.jpg",
                Price = 3900,

                Article = 000000006,
                Size = "",
                Description = "The Longsleeve Carhartt WIP is the perfect choice for those who want comfort, style and quality. Carhartt Longsleeve is suitable for any occasion - from the beach to the street, from the office to the club. The Carhartt work in progress longsleeve has a unisex design, which makes it suitable for  men and women. The CARHARTT WIP embroidery on the  chest gives this T-shirt a special touch of fashion. It is  available in various colors, which allows you to choose a Karhat T-shirt that is right for you. The quality of Carhartt's clothes is impeccable. The Carhartt longsleeve is made of high-quality materials that make it durable and comfortable.You will feel comfortable in this longsleeve Carhart all day long. If you want to add a stylish Carhart longsleeve to your wardrobe that will look fashionable and high-quality, then Carhartt clothes are an excellent choice",
                Count = 99,
                OldPrice = 1900,
                Discount = 1600,
                Composition = "cotton",
                Rating = 5,
                IsFavorite = true,
                IsAvailable = true,
                InStock = 99,
                CategoryId = 0000001,
                Category = new Category
                {
                    Name = "T-Shirt",
                    Description = "",
                    ImagePath = "",
                },
                ImageMiniPath = "../images/Products/T-Shirts/T-Shirt_1.jpg",
            },
            new ProductP
            {
                Name = "T-Shirt 6",
                ShortDescription = "",
                Seller = "From Russia",
                ImagePath = "../images/Products/T-Shirts/T-Shirt_6.jpg",
                Price = 3900,

                Article = 000000007,
                Size = "",
                Description = "The Longsleeve Carhartt WIP is the perfect choice for those who want comfort, style and quality. Carhartt Longsleeve is suitable for any occasion - from the beach to the street, from the office to the club. The Carhartt work in progress longsleeve has a unisex design, which makes it suitable for  men and women. The CARHARTT WIP embroidery on the  chest gives this T-shirt a special touch of fashion. It is  available in various colors, which allows you to choose a Karhat T-shirt that is right for you. The quality of Carhartt's clothes is impeccable. The Carhartt longsleeve is made of high-quality materials that make it durable and comfortable.You will feel comfortable in this longsleeve Carhart all day long. If you want to add a stylish Carhart longsleeve to your wardrobe that will look fashionable and high-quality, then Carhartt clothes are an excellent choice",
                Count = 99,
                OldPrice = 1900,
                Discount = 1600,
                Composition = "cotton",
                Rating = 5,
                IsFavorite = true,
                IsAvailable = true,
                InStock = 99,
                CategoryId = 0000001,
                Category = new Category
                {
                    Name = "T-Shirt",
                    Description = "",
                    ImagePath = "",
                },
                ImageMiniPath = "../images/Products/T-Shirts/T-Shirt_1.jpg",
            },
            new ProductP
            {
                Name = "T-Shirt 7",
                ShortDescription = "",
                Seller = "From Russia",
                ImagePath = "../images/Products/T-Shirts/T-Shirt_7.jpg",
                Price = 3900,

                Article = 000000008,
                Size = "",
                Description = "The Longsleeve Carhartt WIP is the perfect choice for those who want comfort, style and quality. Carhartt Longsleeve is suitable for any occasion - from the beach to the street, from the office to the club. The Carhartt work in progress longsleeve has a unisex design, which makes it suitable for  men and women. The CARHARTT WIP embroidery on the  chest gives this T-shirt a special touch of fashion. It is  available in various colors, which allows you to choose a Karhat T-shirt that is right for you. The quality of Carhartt's clothes is impeccable. The Carhartt longsleeve is made of high-quality materials that make it durable and comfortable.You will feel comfortable in this longsleeve Carhart all day long. If you want to add a stylish Carhart longsleeve to your wardrobe that will look fashionable and high-quality, then Carhartt clothes are an excellent choice",
                Count = 99,
                OldPrice = 1900,
                Discount = 1600,
                Composition = "cotton",
                Rating = 5,
                IsFavorite = true,
                IsAvailable = true,
                InStock = 99,
                CategoryId = 0000001,
                Category = new Category
                {
                    Name = "T-Shirt",
                    Description = "",
                    ImagePath = "",
                },
                ImageMiniPath = "../images/Products/T-Shirts/T-Shirt_1.jpg",
            },
            new ProductP
            {
                Name = "T-Shirt 8",
                ShortDescription = "",
                Seller = "From Russia",
                ImagePath = "../images/Products/T-Shirts/T-Shirt_8.jpg",
                Price = 3900,

                Article = 000000009,
                Size = "",
                Description = "The Longsleeve Carhartt WIP is the perfect choice for those who want comfort, style and quality. Carhartt Longsleeve is suitable for any occasion - from the beach to the street, from the office to the club. The Carhartt work in progress longsleeve has a unisex design, which makes it suitable for  men and women. The CARHARTT WIP embroidery on the  chest gives this T-shirt a special touch of fashion. It is  available in various colors, which allows you to choose a Karhat T-shirt that is right for you. The quality of Carhartt's clothes is impeccable. The Carhartt longsleeve is made of high-quality materials that make it durable and comfortable.You will feel comfortable in this longsleeve Carhart all day long. If you want to add a stylish Carhart longsleeve to your wardrobe that will look fashionable and high-quality, then Carhartt clothes are an excellent choice",
                Count = 99,
                OldPrice = 1900,
                Discount = 1600,
                Composition = "cotton",
                Rating = 5,
                IsFavorite = true,
                IsAvailable = true,
                InStock = 99,
                CategoryId = 0000001,
                Category = new Category
                {
                    Name = "T-Shirt",
                    Description = "",
                    ImagePath = "",
                },
                ImageMiniPath = "../images/Products/T-Shirts/T-Shirt_1.jpg",
            },
        };


            _applicationDbContext.Products.AddRange(product);
            _applicationDbContext.SaveChanges();
        }

        [HttpGet]
        public ViewResult Index()
        {
            try
            {
                var product = _applicationDbContext.Products.Where(p => p.Price == 3900).ToList();
                return View(product);
            }
            catch (Exception ex) 
            { 
            }
            return View();
        }
    }
}
