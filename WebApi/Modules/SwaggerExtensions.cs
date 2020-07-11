using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace eWAN.WebApi.Modules
{
    public static class SwaggerExtensions
    {
        // TODO: Config SwaggerGen
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "eWAN API",
                    Description = "APIs of the School Management Service"
                });
            });
            return services;
        }

        public static IApplicationBuilder UseSwaggerDoc(
            this IApplicationBuilder app
        )
        {
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });

            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "eWAN APIs");
                c.RoutePrefix = string.Empty;
            });
            
            return app;
        }
    }
}
