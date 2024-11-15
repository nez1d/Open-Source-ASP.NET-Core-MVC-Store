using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ShopDevelop.Identity.DuendeServer.Data.IdentityConfigurations;

public static class AuthOptions
{
    public const string ISSUER = "AuthServer";
    public const string AUDDIENCE = "AuthClient";
    internal const string KEY = "mysuperkeywoooooooooooooooochoeeeeeee";
    public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
}