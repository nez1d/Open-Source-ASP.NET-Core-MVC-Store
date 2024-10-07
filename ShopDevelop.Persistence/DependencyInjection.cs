using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ShopDevelop.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ShopDevelop.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            services.AddScoped<IApplicationDbContext>(provider => 
                provider.GetService<ApplicationDbContext>());

            return services;
        }
    }
}