using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopDevelop.Application.Services.Product;

namespace ShopDevelop.WebApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class HomeController : BaseController
{
    private readonly IProductService productService;
    public HomeController(IProductService productService) =>
            this.productService = productService;

    [HttpGet]
    [Authorize(Roles = "AuthUser")]
    public async Task<ActionResult> GetHomeProductList()
    {
        var products = await productService.GetAllProducts();
        return Ok(products);
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
    }*/
}