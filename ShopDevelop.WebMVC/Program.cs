using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddMvc();

builder.Services.TryAddTransient(s => 
{ 
    return s.GetRequiredService<IHttpClientFactory>()
        .CreateClient(string.Empty); 
});

builder.Services.AddHttpClient();

var app = builder.Build();

/*app.Urls.Add("https://localhost:7005/");*/

app.UseRouting();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "product",
    pattern: "{controller=Home}/{action=Index}");
app.MapControllerRoute(
    name: "product",
    pattern: "{controller=Product}/{action=Index}/{id}");

app.Run();