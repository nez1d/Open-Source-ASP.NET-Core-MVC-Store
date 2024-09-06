using Microsoft.EntityFrameworkCore;
using ShopDevelop.Data.DataBase;
using ShopDevelop.Service;
using ShopDevelop.Data.Repository.Entity;
using ShopDevelop.Service.Interfaces;
using ShopDevelop.Data.Entity;
using ShopDevelop.Data.Repository.Interfaces;
using ShopDevelop.Data.Models;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// ��������� ������������ � �������������.
builder.Services.AddControllersWithViews();
// �������� ������ ����������� �� ����� ������������ (appsettings.json).
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
// ���������� Entity Framework Core � �������� �������.
builder.Services.AddDbContext<ApplicationDbContext>(
    options =>
    {
        options.UseNpgsql(connection);
    });

// ���������� Cookie � �������� �������.
builder.Services.AddAuthentication("Cookie")
    .AddCookie("Cookie", config =>
    {
        config.LoginPath = "/Account/Login";
    });

builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = "/Account/Login";
});
// �������� ������������.
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IAuthentificateUserRepository, AuthentificateUserRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped(sp => ShoppingCart.GetCart(sp));
builder.Services.AddScoped<ICurrentUser, CurrentUser>();
builder.Services.AddScoped<IPasswordHasher, ShopDevelop.Data.Entity.PasswordHasher>();
builder.Services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));

builder.Services.AddMvc();

// ��������� AddDistributedMemoryCache.
builder.Services.AddDistributedMemoryCache();
// ��������� ������� ������.
builder.Services.AddSession(options => {
    options.Cookie.Name = ".AspNetCore.Cookies-Session"; // �������� ��� Cookie ������.
    options.IdleTimeout = TimeSpan.FromMinutes(20); // ��������� ������� �������� ������.
    options.Cookie.IsEssential = true;
});
// add security to cookie
builder.Services.AddAuthentication(
    Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults
    .AuthenticationScheme
    ).AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/LogOff";
        options.Cookie.Name = ".AspNetCore.Cookies-Session";
        options.ExpireTimeSpan = TimeSpan.FromDays(1);
        options.SlidingExpiration = true;
    });

var app = builder.Build();

app.Configuration.Bind("Project", new Config());

if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
// ��������� ������.
app.UseSession();
// ��������� �������������.
app.UseRouting();
// ��������� ����������� ������.
app.UseStaticFiles();
// ��������� ��������������.
app.UseAuthentication();
// ��������� �����������.
app.UseAuthorization();
// ��������� cookie.
app.UseCookiePolicy();

// ������������ ������ ��� ��������.
app.MapControllerRoute(
    name: "product",
    pattern: "{controller=Home}/{action=Index}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Item}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Profile}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Cart}/{action=Index}/{id?}");

app.Run();