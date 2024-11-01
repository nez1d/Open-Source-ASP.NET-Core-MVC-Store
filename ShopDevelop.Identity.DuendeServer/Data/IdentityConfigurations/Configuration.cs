using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using IdentityModel;

namespace ShopDevelop.Identity.DuendeServer.Data.IdentityConfigurations;

public static class Configuration
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new ApiScope(AuthConstants.AUTH_IDENTITY_CLIENT_ID,
                         AuthConstants.AUTH_IDENTITY_DISPLAY_NAME)
        };
    public static IEnumerable<ApiResource> ApiResources =>
        new List<ApiResource>
        {
            new ApiResource(AuthConstants.AUTH_IDENTITY_CLIENT_ID,
                            AuthConstants.AUTH_IDENTITY_DISPLAY_NAME, 
                            new [] { JwtClaimTypes.Name })
            {
                Scopes = { AuthConstants.AUTH_IDENTITY_CLIENT_ID }
            }
        };

    public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            new Client
            {
                ClientId = AuthConstants.AUTH_IDENTITY_CLIENT_ID,
                ClientName = AuthConstants.AUTH_IDENTITY_CLIENT_NAME,
                AllowedGrantTypes = GrantTypes.Code,
                RequireClientSecret = false,
                /*ClientSecrets =
                {
                    new Secret(AuthConstants.AUTH_IDENTITY_SECRET_KEY.Sha256())
                },*/
                RequirePkce = true,
                RedirectUris =
                {
                    "http://.../signin-oidc",
                    "https://localhost:7226/Home/Index/",

                },
                AllowedCorsOrigins =
                {
                    "http://..."
                },
                PostLogoutRedirectUris =
                {
                    "http://.../signout-oidc",
                },
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    AuthConstants.AUTH_IDENTITY_CLIENT_ID
                },
                AllowAccessTokensViaBrowser = true
            }
        };
}