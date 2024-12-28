using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopDevelop.Application.Services.Cart;
using ShopDevelop.Application.Services.Category;
using ShopDevelop.Application.Services.Product;
using ShopDevelop.Domain.Models;

namespace ShopDevelop.WebApi.Controllers;

[Route("api/[controller]/[action]/")]
[ApiController]
public class OrderController : BaseController
{
    private readonly ShoppingCartService shoppingCartService;
    private readonly IOrderService orderService;
    
    public OrderController(ShoppingCartService shoppingCartService,
                           IOrderService orderService) =>
        (this.shoppingCartService, this.orderService) = 
        (shoppingCartService, orderService);

    [HttpPost]
    [Authorize("AuthUser")]
    public async Task<IActionResult> Create(string adderss, string city, string counry)
    {
        var items = await shoppingCartService.GetShoppingCartItems();
        var item = items.FirstOrDefault();
        
        if (items.Count() == 0)
        {
            return BadRequest();
        }
        
        await orderService.CreateOrderAsync(
            address: adderss,
            city: city, 
            country: counry,
            productId: item.Product.Id);
        
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