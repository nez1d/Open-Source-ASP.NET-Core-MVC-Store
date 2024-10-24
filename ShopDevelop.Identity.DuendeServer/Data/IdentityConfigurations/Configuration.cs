using Duende.IdentityServer;
using Duende.IdentityServer.Models;

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
        };

    public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            new Client
            {
                ClientId = AuthConstants.AUTH_IDENTITY_CLIENT_ID,
                ClientName = AuthConstants.AUTH_IDENTITY_CLIENT_NAME,
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
                RequirePkce = true,
                RedirectUris =
                {
                    "http://.../signin-oidc"
                },
                AllowedCorsOrigins =
                {
                    "http://..."
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