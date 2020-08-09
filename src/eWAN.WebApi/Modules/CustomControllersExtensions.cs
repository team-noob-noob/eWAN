using Microsoft.Extensions.DependencyInjection;

namespace eWAN.WebApi.Modules
{
    public static class CustomControllersExtensions
    {
        public static IServiceCollection AddCustomControllers(this IServiceCollection services)
        {
            services.AddMvc();
            services
            .AddHttpContextAccessor()
            .AddControllers()
            .AddControllersAsServices();
            return services;
        }
    }
}
