/*using ShopDevelop.Identity.DuendeServer.Models;
using ShopDevelop.Identity.DuendeServer.Service;
using RegisterUserRequest = ShopDevelop.Identity.DuendeServer.Models.RegisterUserRequest;

namespace ShopDevelop.Identity.DuendeServer.Data.Endpoints;

public static class UsersEndpoints
{
    public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/register", Register);

        app.MapPost("/api/login", Login);

        app.MapPost("/api/restore-password", RestorePassword);

        app.MapPost("/api/restore-email", RestoreEmail);

        return app;
    }

    private static async Task<IResult> Register(
        RegisterUserRequest request,
        UserService userService)
    {
        await userService.Register(request.Email, request.Password);
        
        return Results.Ok();
    }

    private static async Task<IResult> Login(
        LoginUserRequest request,
        UserService userService,
        HttpContext httpContext)
    {
        var token = await userService.Login(request.Email!, request.Password!);
        
        httpContext.Response.Cookies.Append("tasty-cookies", token);
        
        return Results.Ok();
    }

    private static async Task<IResult> RestorePassword()
    {
        return Results.Ok();
    }
    
    private static async Task<IResult> RestoreEmail()
    {
        return Results.Ok();
    }
}*/