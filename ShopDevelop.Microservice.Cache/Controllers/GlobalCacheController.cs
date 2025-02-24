using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using ShopDevelop.Microservice.Cache.Services;

namespace ShopDevelop.Microservice.Cache.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GlobalCacheController : ControllerBase
{
    private readonly ILogger logger;
    private readonly ICacheService cacheService;
    public GlobalCacheController(ICacheService cacheService,
        ILogger<GlobalCacheController> logger) => 
        (this.cacheService, this.logger) = (cacheService, logger);

    [HttpGet("[action]")]
    public async Task<IActionResult> SetCache(string? data, uint seconds = 600)
    {
        logger.LogInformation("GlobalCacheController::SetCache");
        
        await cacheService.SetCacheAsync("", data, seconds);
        
        return Ok($"Data set to {data}");
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetCache()
    {
        logger.LogInformation("GlobalCacheController::GetCache");
        
        var result = await cacheService.GetCacheAsync("", this.HttpContext);

        return Ok(result);
    }
}