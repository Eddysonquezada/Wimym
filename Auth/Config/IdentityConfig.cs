using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Config
{
    public static class IdentityConfig
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("Wimym.Api", "sG Wimym API")
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<Client> GetClients(
            IConfiguration configuration
        )
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = configuration.GetValue<string>("Client:ClientId"),
                    ClientName = "Back-office client",
                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,

                    RequireConsent = false,

                    ClientSecrets =
                    {
                        new Secret(configuration.GetValue<string>("Client:SecretKey").Sha256())
                    },

                    RedirectUris           = { $"signin-oidc" },
                    PostLogoutRedirectUris = { $"signout-callback-oidc" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "Wimym.Api",
                    },

                    AllowOfflineAccess = true,

                    // Envía el token por defecto
                    AlwaysIncludeUserClaimsInIdToken = true
                }
            };
        }
    }
}
