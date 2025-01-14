using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ShopDevelop.Application.Services.Cart;
using ShopDevelop.Application.Services.Category;
using ShopDevelop.Application.Services.Product;
using ShopDevelop.Domain.Models;
using ShopDevelop.Identity.DuendeServer.Data;
using ShopDevelop.Identity.DuendeServer.Data.IdentityConfigurations;

namespace ShopDevelop.WebApi.Controllers;

[Route("api/[controller]/[action]/")]
[ApiController]
public class OrderController : BaseController
{
    private readonly ShoppingCartService shoppingCartService;
    private readonly IOrderService orderService;
    private readonly UserManager<ApplicationUser> userManager;
    private readonly JwtProvider jwtProvider;
    
    public OrderController(ShoppingCartService shoppingCartService,
            IOrderService orderService, 
            UserManager<ApplicationUser> userManager,
            JwtProvider jwtProvider) =>
        (this.shoppingCartService, this.orderService,
            this.userManager, this.jwtProvider) = 
        (shoppingCartService, orderService, 
            userManager, jwtProvider);

    [HttpPost]
    [Authorize(Roles = "AuthUser")]
    public async Task<IActionResult> CreateOrder(string address, string city, string country)
    {
        var items = await shoppingCartService.GetShoppingCartItems();

        if (items.Count() == 0)
            return BadRequest("Items count is not null");   
        
        
        string accessToken = HttpContext.Request.Cookies["tasty-cookies"];
        
        var id = jwtProvider.GetUserId(accessToken);

        if (id != null)
        {
            var user = await userManager.FindByIdAsync(id);
            var product = items.FirstOrDefault().Product;

            if (user is not null)
            {
                var order = await orderService.CreateOrderAsync(
                    address: address,
                    city: city,
                    country: country,
                    product: product,
                    user: user);

                if (order)
                    return Ok();
            }
            return BadRequest("User is null. \nuserId: " + id);
        }
        return BadRequest();
    }
    
    [HttpPost]
    [Authorize(Roles = "AuthUser")]
    public async Task<IActionResult> UpdateOrder(Guid orderId, string address, string city, string country)
    {
        if (orderId == Guid.Empty)
            return BadRequest("Invalid order id");    
        
        await orderService.UpdateOrderAsync(orderId, address, city, country);
        return Ok();
    }
    
    [HttpPost]
    [Authorize(Roles = "AuthUser")]
    public async Task<IActionResult> DeleteOrder(Guid orderId)
    {
        await orderService.DeleteOrderAsync(orderId);
        return Ok();
    }

    [HttpGet]
    [Authorize(Roles = "AuthUser")]
    public async Task<IActionResult> GetOrders()
    {
        string accessToken = HttpContext.Request.Cookies["tasty-cookies"];
        
        var id = jwtProvider.GetUserId(accessToken);
        
        var items = await orderService.GetOrdersByUserIdAsync(id);
        
        if(!items.Any())
            return Ok("The number of orders is zero.");
        
        return Ok(items);
    }
}