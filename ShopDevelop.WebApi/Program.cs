using ShopDevelop.Application;
using ShopDevelop.Application.Repository;
using ShopDevelop.Application.Services.Product;
using ShopDevelop.Persistence;
using ShopDevelop.Application.Services.Category;
using ShopDevelop.Application.Services.Review;
using ShopDevelop.Application.Services.User;
using ShopDevelop.Persistence.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopDevelop.Application.Services.Cart;
using ShopDevelop.Application.Services.Seller;
using ShopDevelop.Domain.Interfaces;
using ShopDevelop.Domain.Models;
using ShopDevelop.Identity.DuendeServer.Data;
using ShopDevelop.Identity.DuendeServer.Service.Identity;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var connectionString = builder.Configuration.GetValue<string>("DefaultConnection");

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(connectionString);
});

builder.Services.AddDbContext<AuthDbContext>(optoins =>
{
    optoins.UseNpgsql(connectionString);
});

builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
builder.Services.AddScoped<AuthDbContext>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<ISellerRepository, SellerRepository>();
builder.Services.AddScoped<ISellerService, SellerService>();
builder.Services.AddScoped<ReviewRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped(scope => ShoppingCartService.GetCart(scope));

builder.Services.AddSession(options => {
    options.Cookie.Name = ".AspNetCore.Cookies.Session";
    options.IdleTimeout = TimeSpan.FromHours(24);
    options.Cookie.IsEssential = true;
});

builder.Services.AddIdentityServer(options =>
{
    options.Authentication.CookieLifetime = TimeSpan.FromHours(10);
});

builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme =
        JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme =
        JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("mysuperkeywoooooooooooooooochoeeeeeee"))
        };
        options.Authority = "http://localhost:5261/";
        options.Audience = "NotesWebAPI";
        options.RequireHttpsMetadata = false;
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                context.Token = context.Request.Cookies["tasty-cookies"];
                return Task.CompletedTask;
            }
        };
    }).AddCookie(options =>
    {
        options.Cookie.Name = "tasty-cookies";
    });

builder.Services.AddApplication();
builder.Services.AddPersistence(configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});

var app = builder.Build();

app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseHsts();
app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

app.UseSwagger();
app.UseSwaggerUI(config =>
{
    config.RoutePrefix = string.Empty;
    config.SwaggerEndpoint("swagger/v1/swagger.json", "Shop API");
});

app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();