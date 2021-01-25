// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System;
using System.Linq;
using System.Security.Claims;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using eWAN.Infrastructure.Database;
using eWAN.Domains.Role;

namespace eWAN.Identity
{
    public class SeedData
    {
        public static void EnsureSeedData(string connectionString)
        {
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddDbContext<EwanIdentityDbContext>(options =>
               options.UseMySql(connectionString));

            services.AddIdentity<eWAN.Infrastructure.Database.Entities.Identity, IdentityRole>()
                .AddEntityFrameworkStores<EwanIdentityDbContext>()
                .AddDefaultTokenProviders();

            using (var serviceProvider = services.BuildServiceProvider())
            {
                using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var roleMgr = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                    SeedData.InsertRoles(roleMgr);
                    roleMgr.Dispose();

                    var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<eWAN.Infrastructure.Database.Entities.Identity>>();
                    SeedData.InsertUsers(userMgr);
                    userMgr.Dispose();
                }
            }
        }

        

        private static void InsertRoles(RoleManager<IdentityRole> roleManager)
        {
            void InsertRole(string roleName, RoleManager<IdentityRole> roleManager)
            {
                var role = roleManager.FindByNameAsync(roleName).Result;
                if(role == null)
                {
                    role = new IdentityRole(roleName);

                    var result = roleManager.CreateAsync(role).Result;
                    if(!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }
                    Log.Debug($"{roleName} role created");
                }
                else
                {
                    Log.Debug($"{roleName} already exists");
                }
            }

            InsertRole("student", roleManager);
            InsertRole("applicant", roleManager);
        }

        private static void InsertUsers(UserManager<eWAN.Infrastructure.Database.Entities.Identity> userMgr)
        {
            var alice = userMgr.FindByNameAsync("alice").Result;
            if (alice == null)
            {
                alice = new eWAN.Infrastructure.Database.Entities.Identity()
                {
                    UserName = "alice",
                    Email = "AliceSmith@email.com",
                    EmailConfirmed = true,
                    FirstName = "Alice",
                    MiddleName = "Absr",
                    LastName = "Smith",
                    HomeAddress = "Bahay"
                };
                var result = userMgr.CreateAsync(alice, "Pass123$").Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }

                var roleResult = userMgr.AddToRoleAsync(alice, "student").Result;
                if(!roleResult.Succeeded)
                {
                    throw new Exception(roleResult.Errors.First().Description);
                }

                result = userMgr.AddClaimsAsync(alice, new Claim[]{
                            new Claim(JwtClaimTypes.Name, "Alice Smith"),
                            new Claim(JwtClaimTypes.GivenName, "Alice"),
                            new Claim(JwtClaimTypes.FamilyName, "Smith"),
                            new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
                        }).Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }
                Log.Debug("alice created");
            }
            else
            {
                Log.Debug("alice already exists");
            }

            var bob = userMgr.FindByNameAsync("bob").Result;
            if (bob == null)
            {
                bob = new eWAN.Infrastructure.Database.Entities.Identity()
                {
                    UserName = "bob",
                    Email = "BobSmith@email.com",
                    EmailConfirmed = true,
                    FirstName = "Bob",
                    MiddleName = "asda",
                    LastName = "Smith",
                    HomeAddress = "Bahay"
                };
                var result = userMgr.CreateAsync(bob, "Pass123$").Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }
                var roleResult = userMgr.AddToRoleAsync(bob, "applicant").Result;
                if(!roleResult.Succeeded)
                {
                    throw new Exception(roleResult.Errors.First().Description);
                }

                result = userMgr.AddClaimsAsync(bob, new Claim[]{
                            new Claim(JwtClaimTypes.Name, "Bob Smith"),
                            new Claim(JwtClaimTypes.GivenName, "Bob"),
                            new Claim(JwtClaimTypes.FamilyName, "Smith"),
                            new Claim(JwtClaimTypes.WebSite, "http://bob.com"),
                            new Claim("location", "somewhere")
                        }).Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }
                Log.Debug("bob created");
            }
            else
            {
                Log.Debug("bob already exists");
            }
        }
    }
}
