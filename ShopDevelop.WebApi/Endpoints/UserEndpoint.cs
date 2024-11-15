/*using ShopDevelop.Application.Services.User;
using ShopDevelop.Domain.Contracts.Users;

namespace ShopDevelop.WebApi.Endpoints;

public static class UserEndpoint
{
    public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("register", );

        app.MapPost("login", Login);

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
        UserService service,
        HttpContext context)
    {
        context.Response.Cookies.Append("tasty-cookies", token);

        return Results.Ok();
    }
}
*/