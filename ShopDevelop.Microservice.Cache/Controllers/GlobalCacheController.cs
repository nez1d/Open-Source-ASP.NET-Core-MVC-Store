using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace ShopDevelop.Microservice.Cache.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GlobalCacheController : ControllerBase
{
    private const string keyName = "CacheKeyName";
    private readonly IDistributedCache distributedCache;
    public GlobalCacheController(IDistributedCache distributedCache) => 
        this.distributedCache = distributedCache;

    [HttpGet("[action]")]
    public async Task<IActionResult> SetCache(string? data, int seconds = 10)
    {
        data ??= DateTime.Now.ToString("F");
        await distributedCache.SetStringAsync(keyName, data, new DistributedCacheEntryOptions
        {
            AbsoluteExpiration = DateTime.Now.AddSeconds(seconds)
        });
        
        return Ok($"Data set to {data}");
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetCache()
    {
        var isExist = await distributedCache.GetStringAsync(keyName, HttpContext.RequestAborted);

        var message = isExist is not null
            ? $"Data in cache{isExist}"
            : "No data in cache";
        
        return Ok(message);
    }
}