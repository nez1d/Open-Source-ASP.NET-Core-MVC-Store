namespace ShopDevelop.Microservice.Cache.Services;

public interface ICacheService
{
    Task SetCacheAsync(string key, string? data, uint seconds);
    Task<string> GetCacheAsync(string key, HttpContext context);
}