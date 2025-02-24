using Microsoft.IdentityModel.Tokens;
using ShopDevelop.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShopDevelop.Identity.DuendeServer.WebAPI.Data.IdentityConfigurations;

public class JwtProvider
{
    public string GenerateToken(ApplicationUser user)
    {
        Claim[] claims = 
        [
            new("UserId", user.Id.ToString()),
            new(ClaimTypes.Role, "AuthUser"),
            new(ClaimTypes.Name, user.Email!)
        ];

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AuthOptions.KEY)),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            signingCredentials: signingCredentials,
            expires: DateTime.UtcNow.AddHours(12));

        var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

        return tokenValue;
    }

    public string GetUserId(string token)
    {
        var key = Encoding.UTF8.GetBytes(AuthOptions.KEY);
        var handler = new JwtSecurityTokenHandler();
        var validation = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
        };
        
        var claims = handler.ValidateToken(token, validation, out var tokenSecure);
        var userId = claims.FindFirstValue("UserId");
        
        return userId;
    }
    
    /*public Guid GetUserGmail(string token)
    {
        var key = Encoding.UTF8.GetBytes(AuthOptions.KEY);
        var handler = new JwtSecurityTokenHandler();
        var validation = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
        };
        
        var claims = handler.ValidateToken(token, validation, out var tokenSecure);
        var userId = claims.FindFirstValue("UserId");
        
        return Guid.Parse(userId);
    }*/
}