// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace Sinuka.Web
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource("Roles", new List<string> { "Machine", "Admin", "Staff", "Public" })
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("ClientToIdentity"),
                new ApiScope("Admin"),
                new ApiScope("Staff"),
                new ApiScope("Public"),
            };

        public static IEnumerable<ApiResource> ApiResources => 
            new ApiResource[]
            {
                new ApiResource()
                {
                    Name = "Sinuka.Web.Accounts",
                    DisplayName = "Sinuka Accounts External Client Integration",
                    Description = "API for adding account registrations",
                    Scopes = new List<string> {"ClientToIdentity"},
                    ApiSecrets = new List<Secret> {new Secret("ScopeSecret".Sha256())},
                    UserClaims = new List<string> {"Role"},
                },
                new ApiResource()
                {
                    Name = "Sinuka.Web.Admin",
                    DisplayName = "Sinuka Accounts Admin Web APIs",
                    Description = "Web APIs for Admin Controls",
                    Scopes = new List<string> {"Admin"},
                    ApiSecrets = new List<Secret> {new Secret("ScopeSecret".Sha256())},
                    UserClaims = new List<string> {"Role"},
                }
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // m2m client credentials flow client
                new Client
                {
                    ClientId = "sinukaWebAccounts",
                    ClientName = "Sinuka Web Accounts",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                    AllowedScopes = { "ClientToIdentity" }
                },

                new Client
                {
                    ClientId = "sinukaWebAdminUI",
                    ClientName = "Sinuka Web Admin UI",
                    ClientUri = "https://localhost:7001",

                    AllowedGrantTypes = GrantTypes.Implicit,

                    AllowedCorsOrigins = { "https://localhost:7001" },
                    RedirectUris = { "https://localhost:7001/signin-oidc" },
                    FrontChannelLogoutUri = "https://localhost:7001/signout-oidc",
                    PostLogoutRedirectUris = { "https://localhost:7001/signout-oidc" },

                    AllowedScopes = {"openid", "profile", "Admin"},

                    AllowAccessTokensViaBrowser = true,
                },
            };
    }
}