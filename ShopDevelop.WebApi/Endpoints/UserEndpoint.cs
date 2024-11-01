/*using ShopDevelop.Application.Services.User;

namespace ShopDevelop.WebApi.Endpoints;

public static class UserEndpoint
{
    public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("register", Register);

        app.MapPost("login", Login);

        return app;
    }

    private static async Task<IResult> Register(
        RegisterUserRequest request,
        UserService userService)
    {
        await userService.Register(request.Email, request.Passowrd);

        return Results.Ok();
    }

    private static async Task<IResult> Login()
    {
        return Results.Ok();
    }
}
*/