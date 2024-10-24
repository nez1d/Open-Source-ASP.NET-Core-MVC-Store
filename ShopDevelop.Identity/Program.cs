using Microsoft.EntityFrameworkCore;
using ShopDevelop.Identity.Data;
using ShopDevelop.Identity.Models.User;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
builder.Services.AddDbContext<AuthDbContext>(options =>
{
    options.UseNpgsql(configuration
        .GetConnectionString("DefaultConnection"));
})
    .AddIdentity<AppUser, AppRole>(config =>
{
    config.Password.RequireDigit = false;
    config.Password.RequireLowercase = false;
    config.Password.RequireNonAlphanumeric = false;
    config.Password.RequireUppercase = false;
    config.Password.RequiredLength = 1;
})
    .AddEntityFrameworkStores<AuthDbContext>();

builder.Services.AddControllersWithViews();

builder.Services.ConfigureApplicationCookie(config =>
{
    config.Cookie.HttpOnly = true;
    config.ExpireTimeSpan = TimeSpan.FromDays(1);

    config.LoginPath = "/Auth/Login";
    config.LogoutPath = "/Auth/Logout";
    config.AccessDeniedPath = "/Auth/AccesDenied";
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", builder =>
    {
        builder.RequireClaim(ClaimTypes.Role, "Admin");
    });
    options.AddPolicy("Manager", builder =>
    {
        builder.RequireClaim(ClaimTypes.Role, "Manager");
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider
            .GetRequiredService<AuthDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception exception)
    {
        var logger = serviceProvider.GetRequiredService
            <ILogger<Program>>();
        logger.LogError(exception, "An error ocurred app initialization");
    }
}

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseCookiePolicy();
app.UseStaticFiles();

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});
app.Run();
