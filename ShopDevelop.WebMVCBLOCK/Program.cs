using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddMvc();

builder.Services.TryAddTransient(s => 
{ 
    return s.GetRequiredService<IHttpClientFactory>()
        .CreateClient(string.Empty); 
});

builder.Services.AddAuthentication("cookie")
    .AddCookie("cookie", options =>
    {
        options.Cookie.HttpOnly = true;
        options.Cookie.Name = "Asp.Net.Core.Authefication-cookie";
        options.ExpireTimeSpan = TimeSpan.FromHours(8);
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AuthUser", new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .RequireClaim("role", "AuthUser")
        .Build());
    options.AddPolicy("AuthUser", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim(ClaimTypes.Role, "AuthUser");
    });
    options.AddPolicy("Admin", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim(ClaimTypes.Role, "Admin");
    });
    options.AddPolicy("Moderator", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim(ClaimTypes.Role, "Moderator");
    });
});

builder.Services.AddHttpClient();

var app = builder.Build();

/*app.Urls.Add("https://localhost:7005/");*/

app.UseRouting();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "product",
    pattern: "{controller=Home}/{action=Index}");
app.MapControllerRoute(
    name: "product",
    pattern: "{controller=Product}/{action=Index}/{id}");

app.Run();