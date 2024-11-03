using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShopDevelop.Application.Services;
using ShopDevelop.Identity.DuendeServer.Data;
using ShopDevelop.Identity.DuendeServer.Data.IdentityConfigurations;
using ShopDevelop.Identity.DuendeServer.Models;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetValue<string>("DefaultConnection");

builder.Services.AddDbContext<AuthDbContext>(optoins =>
{
    optoins.UseNpgsql(connectionString);
});

builder.Services.AddAuthentication("cookie")
    .AddCookie("cookie", options =>
    {
        options.Cookie.HttpOnly = true;
        options.Cookie.Name = "Asp.Net.Core.Authefication-cookie";
        options.ExpireTimeSpan = TimeSpan.FromHours(8);

        options.LoginPath = "/Auth/Login";
        options.LogoutPath = "/Auth/Logout";
        options.AccessDeniedPath = "/Auth/AccessDenied";
    });
    /*.AddGoogle("Google", options =>
    {
        options.ClientId = "";
        options.ClientSecret = "";

        //options.CallbackPath = "/singin-google";
        //options.SignInScheme = "cookie";

        options.Events = new OAuthEvents
        {
            OnCreatingTicket = e =>
            {
                e.Principal
            }
        };
    });*/

builder.Services.AddAuthorization(options =>
{
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

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddEntityFrameworkStores<AuthDbContext>()
    .AddSignInManager<SignInManager<ApplicationUser>>()
    .AddRoleManager<RoleManager<ApplicationRole>>()
    .AddDefaultTokenProviders(); 

builder.Services.Configure<IdentityOptions>(options => 
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 8;
    options.Password.RequiredUniqueChars = 1;

    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_.,@-+";
    options.User.RequireUniqueEmail = true;
});

builder.Services.AddIdentityServer()
    .AddInMemoryApiResources(Configuration.ApiResources)
    .AddInMemoryIdentityResources(Configuration.IdentityResources)
    .AddInMemoryApiScopes(Configuration.ApiScopes)
    .AddInMemoryClients(Configuration.Clients)
    .AddDeveloperSigningCredential();

builder.Services.AddRazorPages();

builder.Services.AddControllers();

/*builder.Services.AddScoped<IIdentityService, IdentityService>();*/

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

using(var scope = app.Services.CreateScope())
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
        var logger = serviceProvider
            .GetRequiredService<ILogger<Program>>();
        logger.LogError(exception, "An error occurred app initialization");
    }
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();