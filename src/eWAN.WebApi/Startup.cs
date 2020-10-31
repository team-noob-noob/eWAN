using Elastic.Apm.NetCoreAll;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using eWAN.WebApi.Modules;
using eWAN.Modules.Autofac;
using eWAN.Modules.Microsoft;
using eWAN.Infrastructure.Auth;
using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace eWAN.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public ILifetimeScope AutofacContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddPresenters();
            services.AddCustomControllers();
            services.AddCustomAuthentication();
            services.AddSwagger();
            services.AddOptions();
        }

        // Autofac Specific Dependencies
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.AddPersistence();
            builder.AddServices();
            builder.AddUseCases();
            builder.AddMonitoring();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            app.UseAllElasticApm();

            app.UseHttpsRedirection();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerDoc();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
