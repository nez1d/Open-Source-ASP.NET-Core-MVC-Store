using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace ShopDevelop.Microservice.Cache.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocalCacheController : ControllerBase
{
    private const string keyName = "CacheKeyName";
    private readonly IMemoryCache memoryCache;
    
    public LocalCacheController(IMemoryCache memoryCache) => 
        this.memoryCache = memoryCache;

    [HttpGet("[action]")]
    public async Task<IActionResult> SetCache(string? data, int seconds = 10)
    {
        data ??= DateTime.Now.ToString("F");
        memoryCache.Set(keyName, data, DateTime.Now.AddSeconds(seconds));
        
        return Ok($"Data set to {data}");
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetCache()
    {
        var isExist = !memoryCache.TryGetValue(keyName, out string? value);

        var message = isExist
            ? "No data in cache"
            : $"Data in cache{value}";

        return Ok(message);
    }
}