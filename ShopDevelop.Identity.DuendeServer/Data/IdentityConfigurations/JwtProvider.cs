using Microsoft.IdentityModel.Tokens;
using ShopDevelop.Domain.Models;
using ShopDevelop.Identity.DuendeServer.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShopDevelop.Identity.DuendeServer.Data.IdentityConfigurations;

public class JwtProvider
{
    public string GenerateToken(ApplicationUser user)
    {
        Claim[] claims = [new(ClaimTypes.Role, "AuthUser")];

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
}