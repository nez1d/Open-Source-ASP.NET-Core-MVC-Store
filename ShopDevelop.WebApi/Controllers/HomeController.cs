﻿/*using Microsoft.AspNetCore.Mvc;
using ShopDevelop.Application.Repository;
using ShopDevelop.Application.Services.Product;

namespace ShopDevelop.WebApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class HomeController : BaseController
{
    private readonly IProductService productService;
    private readonly IProductRepository productRepository;
    public HomeController(IProductService productService,
        IProductRepository productRepository) =>
            (this.productService, this.productRepository) = 
            (productService, productRepository);

    [HttpGet]
    public async Task<ActionResult> GetHomeProductList()
    {
        /*var products = await productService.GetAllProductsAsync();#1#
        /*return Ok(products);#1#

        return null;
    }

    /*[HttpGet("token")]
    public dynamic GetToken()
    {
        var handler = new JwtSecurityTokenHandler();

        var sec = "mysuperkeywoooooooooooooooochoeeeeeee";
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(sec));
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

        var identity = new ClaimsIdentity(new GenericIdentity("temp@jwt.ru"), 
            new[] { new Claim(ClaimTypes.Role, "AuthUser") });
        var token = handler.CreateJwtSecurityToken(subject: identity,
                                                   signingCredentials: signingCredentials,
                                                   audience: "AuthClient",
                                                   issuer: "AuthServer",
                                                   expires: DateTime.UtcNow.AddHours(42));
        return handler.WriteToken(token);
    }#1#
}*/