using Microsoft.Extensions.Caching.Distributed;

namespace ShopDevelop.Microservice.Cache.Services;

public class CacheService : ICacheService
{
    private readonly IDistributedCache distributedCache;

    public CacheService(IDistributedCache distributedCache) => 
        (this.distributedCache) = (distributedCache);
    
    public async Task SetCacheAsync(string key, string? data, uint seconds)
    {
        data ??= DateTime.Now.ToString("F");
        await distributedCache.SetStringAsync(key, data, new DistributedCacheEntryOptions
        {
            AbsoluteExpiration = DateTime.Now.AddSeconds(seconds)
        });
    }

    public async Task<string> GetCacheAsync(string key, HttpContext context)
    {
        var isExist = await distributedCache.GetStringAsync(key, context.RequestAborted);

        var message = isExist is not null
            ? $"Data in cache {isExist}"
            : "No data in cache";
        
        return message;
    } 
}