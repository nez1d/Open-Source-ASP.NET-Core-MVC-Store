using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Owin;
using ShopDevelop.Application.Services.Cart;
using ShopDevelop.Application.Services.Category;
using ShopDevelop.Domain.Models;
using ShopDevelop.Identity.DuendeServer.Data;
using ShopDevelop.Identity.DuendeServer.Service.Identity;

namespace ShopDevelop.WebApi.Controllers;

[Route("api/[controller]/[action]/")]
[ApiController]
public class OrderController : BaseController
{
    private readonly ShoppingCartService shoppingCartService;
    private readonly IOrderService orderService;
    private readonly UserManager<ApplicationUser> userManager;
    private readonly IHttpContextAccessor httpContextAccessor;
    
    public OrderController(ShoppingCartService shoppingCartService,
            IOrderService orderService,
            UserManager<ApplicationUser> userManager,
            IHttpContextAccessor httpContextAccessor) =>
        (this.shoppingCartService, this.orderService, this.userManager, 
            this.httpContextAccessor) = 
        (shoppingCartService, orderService, userManager, 
            httpContextAccessor);

    [HttpGet]
    public async Task<ApplicationUser> Get()
    {
        var userId = User.FindFirst("UserId")?.Value;

        if (userId is not null)
        {
            var manager = HttpContext.RequestServices.GetRequiredService<UserManager<ApplicationUser>>();
            return await manager.FindByIdAsync(userId);    
        }
        
        return null;
    }

    [HttpPost]
    [Authorize(Roles = "AuthUser")]
    public async Task<IActionResult> Create(string adderss, string city, string counry)
    {
        var items = await shoppingCartService.GetShoppingCartItems();

        if (items.Count() == 0)
        {
            return BadRequest();   
        }

        try
        {
            var user = await Get();
            
            foreach (var item in items)
            {
                await orderService.CreateOrderAsync(
                    address: adderss,
                    city: city, 
                    country: counry,
                    productId: item.Product.Id,
                    user: user);
            }
        }
        catch (Exception ex) { }
        
        return Ok();
    }
    
    [HttpGet]
    [Authorize("AuthUser")]
    public async Task CheckoutOrderAsync()
    {
        var items = await shoppingCartService.GetShoppingCartItems();
        shoppingCartService.ShoppingCartItems = items;

        if (items.Count() == 0)
        {
            return;
        }
    }
}