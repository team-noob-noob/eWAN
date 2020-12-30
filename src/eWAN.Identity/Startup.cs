// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using eWAN.Infrastructure.Database;
using eWAN.Infrastructure.Database.Entities;
using eWAN.Modules.Autofac;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using IdentityServer4.Configuration;
using Elastic.Apm.NetCoreAll;

namespace eWAN.Identity
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;
        }

        public ILifetimeScope AutofacContainer { get; private set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            // services.AddDbContext<EwanIdentityDbContext>(options =>
            //     options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<eWAN.Infrastructure.Database.Entities.Identity, IdentityRole>()
                .AddEntityFrameworkStores<EwanIdentityDbContext>()
                .AddDefaultTokenProviders();

            var builder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;

                // see https://identityserver4.readthedocs.io/en/latest/topics/resources.html
                options.EmitStaticAudienceClaim = true;
            })
                .AddInMemoryIdentityResources(Config.IdentityResources)
                .AddInMemoryApiScopes(Config.ApiScopes)
                .AddInMemoryClients(Config.Clients)
                .AddAspNetIdentity<eWAN.Infrastructure.Database.Entities.Identity>();

            // not recommended for production - you need to store your key material somewhere secure
            builder.AddDeveloperSigningCredential();
            services.AddAuthentication();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.AddMonitoring();
            builder.Register(c => {
                var options = new DbContextOptionsBuilder<EwanIdentityDbContext>();
                options.UseLazyLoadingProxies();
                return new EwanIdentityDbContext(options.Options);
            }).AsSelf().InstancePerLifetimeScope();
        }

        public void Configure(IApplicationBuilder app)
        {
            this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            app.UseAllElasticApm();

            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }

            app.UseStaticFiles();

            app.UseRouting();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}