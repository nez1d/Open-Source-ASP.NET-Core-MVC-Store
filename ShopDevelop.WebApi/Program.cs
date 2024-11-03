using ShopDevelop.Application;
using ShopDevelop.Persistence;
using ShopDevelop.Application.Repository;
using ShopDevelop.Persistence.Repository;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

/*builder.Services.AddMediatR(config =>
    config.RegisterServicesFromAssemblies(
        typeof(CreateProductCommandHandler).Assembly, 
        typeof(CreateProductCommand).Assembly));*/

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();