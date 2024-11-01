using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopDevelop.Application.Repository;

namespace ShopDevelop.WebApi.Controllers;

public class HomeController : BaseController
{
    private readonly IProductRepository productRepository;
    public HomeController(IProductRepository productRepository) =>
        this.productRepository = productRepository;
    
    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        try
        {
            var products = productRepository.GetAll();
            return Ok(products);
        }
        catch (Exception ex)
        {
        }
        return Ok();
    }

    [HttpPost]
    [Authorize(Roles = "AuthUser")]
    public async Task<ActionResult<Guid>> Create()
    {
        /*var product = new Product
        {
            Article = 00001,
            ProductName = "T-Shirt 1",
            Price = 3900,
            OldPrice = 1900,
            Discount = 1600,
            ShortDescription = "",
            Description = "The Longsleeve Carhartt WIP is the perfect choice for those who want comfort, style and quality. Carhartt Longsleeve is suitable for any occasion - from the beach to the street, from the office to the club. The Carhartt work in progress longsleeve has a unisex design, which makes it suitable for  men and women. The CARHARTT WIP embroidery on the  chest gives this T-shirt a special touch of fashion. It is  available in various colors, which allows you to choose a Karhat T-shirt that is right for you. The quality of Carhartt's clothes is impeccable. The Carhartt longsleeve is made of high-quality materials that make it durable and comfortable.You will feel comfortable in this longsleeve Carhart all day long. If you want to add a stylish Carhart longsleeve to your wardrobe that will look fashionable and high-quality, then Carhartt clothes are an excellent choice",
            InStock = 52,
            IsFavorite = true,
            IsAvailable = true,
            ImagePath = "../images/Products/T-Shirts/T-Shirt_1.jpg",
            ImageMiniPath = "../images/Products/T-Shirts/T-Shirt_1.jpg",
            Rating = 5,
            Category = new Category
            {
                Name = "T-Shirt",
                Description = "",
                ImagePath = "",
            },
            Seller = new Seller
            {
                Login = "Login",
                Password = "Password",
                FirstName = "FirstName",
                LastName = "LastName",
                Patronymic = "Patronymic"
            }
        };

        await productRepository.Create(product);*/
        return Ok();
    }

    /*public void AddProduct()
    {

        var product = new List<Product>
            {
                new Product
                {
                    ProductName = "T-Shirt 1",
                    ShortDescription = "",
                    ImagePath = "../images/Products/T-Shirts/T-Shirt_1.jpg",
                    Price = 3900,
                    Article = 000000002,
                    Description = "The Longsleeve Carhartt WIP is the perfect choice for those who want comfort, style and quality. Carhartt Longsleeve is suitable for any occasion - from the beach to the street, from the office to the club. The Carhartt work in progress longsleeve has a unisex design, which makes it suitable for  men and women. The CARHARTT WIP embroidery on the  chest gives this T-shirt a special touch of fashion. It is  available in various colors, which allows you to choose a Karhat T-shirt that is right for you. The quality of Carhartt's clothes is impeccable. The Carhartt longsleeve is made of high-quality materials that make it durable and comfortable.You will feel comfortable in this longsleeve Carhart all day long. If you want to add a stylish Carhart longsleeve to your wardrobe that will look fashionable and high-quality, then Carhartt clothes are an excellent choice",
                    OldPrice = 1900,
                    Discount = 1600,
                    Rating = 5,
                    IsFavorite = true,
                    IsAvailable = true,
                    InStock = 99,
                    Category = new Category
                    {
                        Name = "T-Shirt",
                        Description = "",
                        ImagePath = "",
                    },
                    ImageMiniPath = "../images/Products/T-Shirts/T-Shirt_1.jpg",
                },
                new Product
                {
                    ProductName = "T-Shirt 1",
                    ShortDescription = "",
                    ImagePath = "../images/Products/T-Shirts/T-Shirt_1.jpg",
                    Price = 3900,
                    Article = 000000002,
                    Description = "The Longsleeve Carhartt WIP is the perfect choice for those who want comfort, style and quality. Carhartt Longsleeve is suitable for any occasion - from the beach to the street, from the office to the club. The Carhartt work in progress longsleeve has a unisex design, which makes it suitable for  men and women. The CARHARTT WIP embroidery on the  chest gives this T-shirt a special touch of fashion. It is  available in various colors, which allows you to choose a Karhat T-shirt that is right for you. The quality of Carhartt's clothes is impeccable. The Carhartt longsleeve is made of high-quality materials that make it durable and comfortable.You will feel comfortable in this longsleeve Carhart all day long. If you want to add a stylish Carhart longsleeve to your wardrobe that will look fashionable and high-quality, then Carhartt clothes are an excellent choice",
                    OldPrice = 1900,
                    Discount = 1600,
                    Rating = 5,
                    IsFavorite = true,
                    IsAvailable = true,
                    InStock = 99,
                    Category = new Category
                    {
                        Name = "T-Shirt",
                        Description = "",
                        ImagePath = "",
                    },
                    ImageMiniPath = "../images/Products/T-Shirts/T-Shirt_1.jpg",
                },
                new Product
                {
                    ProductName = "T-Shirt 1",
                    ShortDescription = "",
                    ImagePath = "../images/Products/T-Shirts/T-Shirt_1.jpg",
                    Price = 3900,
                    Article = 000000002,
                    Description = "The Longsleeve Carhartt WIP is the perfect choice for those who want comfort, style and quality. Carhartt Longsleeve is suitable for any occasion - from the beach to the street, from the office to the club. The Carhartt work in progress longsleeve has a unisex design, which makes it suitable for  men and women. The CARHARTT WIP embroidery on the  chest gives this T-shirt a special touch of fashion. It is  available in various colors, which allows you to choose a Karhat T-shirt that is right for you. The quality of Carhartt's clothes is impeccable. The Carhartt longsleeve is made of high-quality materials that make it durable and comfortable.You will feel comfortable in this longsleeve Carhart all day long. If you want to add a stylish Carhart longsleeve to your wardrobe that will look fashionable and high-quality, then Carhartt clothes are an excellent choice",
                    OldPrice = 1900,
                    Discount = 1600,
                    Rating = 5,
                    IsFavorite = true,
                    IsAvailable = true,
                    InStock = 99,
                    Category = new Category
                    {
                        Name = "T-Shirt",
                        Description = "",
                        ImagePath = "",
                    },
                    ImageMiniPath = "../images/Products/T-Shirts/T-Shirt_1.jpg",
                },
                new Product
                {
                    ProductName = "T-Shirt 1",
                    ShortDescription = "",
                    ImagePath = "../images/Products/T-Shirts/T-Shirt_1.jpg",
                    Price = 3900,
                    Article = 000000002,
                    Description = "The Longsleeve Carhartt WIP is the perfect choice for those who want comfort, style and quality. Carhartt Longsleeve is suitable for any occasion - from the beach to the street, from the office to the club. The Carhartt work in progress longsleeve has a unisex design, which makes it suitable for  men and women. The CARHARTT WIP embroidery on the  chest gives this T-shirt a special touch of fashion. It is  available in various colors, which allows you to choose a Karhat T-shirt that is right for you. The quality of Carhartt's clothes is impeccable. The Carhartt longsleeve is made of high-quality materials that make it durable and comfortable.You will feel comfortable in this longsleeve Carhart all day long. If you want to add a stylish Carhart longsleeve to your wardrobe that will look fashionable and high-quality, then Carhartt clothes are an excellent choice",
                    OldPrice = 1900,
                    Discount = 1600,
                    Rating = 5,
                    IsFavorite = true,
                    IsAvailable = true,
                    InStock = 99,
                    Category = new Category
                    {
                        Name = "T-Shirt",
                        Description = "",
                        ImagePath = "",
                    },
                    ImageMiniPath = "../images/Products/T-Shirts/T-Shirt_1.jpg",
                },
            };
    }*/
}
