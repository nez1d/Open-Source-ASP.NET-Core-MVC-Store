using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ShopDevelop.Application.Services.Product;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace ShopDevelop.WebApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class HomeController : BaseController
{
    private readonly IProductService productService;
    public HomeController(IProductService productService) =>
            this.productService = productService;

    [HttpGet]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    /*[Authorize(Policy = "AuthUser")]*/
    public async Task<ActionResult> GetHomeProductList()
    {
        var products = await productService.GetAllProducts();
        return Ok(products);
    }
}