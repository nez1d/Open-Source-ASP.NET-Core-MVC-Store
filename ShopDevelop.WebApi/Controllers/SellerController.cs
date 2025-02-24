/*using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopDevelop.Application.Services.Seller;
using ShopDevelop.Domain.Entities;

namespace ShopDevelop.WebApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class SellerController : BaseController
{
    private readonly ISellerService sellerService;
    public SellerController(ISellerService sellerService) =>
        this.sellerService = sellerService;

    [HttpPost]
    [Authorize(Roles = "AuthUser")]
    public async Task<IActionResult> CreateSeller(
        string name, string description)
    {
        await sellerService.CreateSellerAsync(name, description, "/", "/");
        return Ok();
    }

    [HttpPost]
    [Authorize(Roles = "Manager")]
    public async Task<IActionResult> EditSeller(Seller model)
    {
        await sellerService.EditSellerAsync(model);
        return Ok();  
    }

    [HttpPost]
    [Authorize(Roles = "Manager")]
    public async Task<IActionResult> DeleteSeller(Guid id)
    {
        await sellerService.DeleteSellerAsync(id);
        return Ok();
    }
}*/