using Microsoft.Extensions.DependencyInjection;

namespace eWAN.WebApi.Modules
{
    using Application.Services;
    using Infrastructure.Hashing;

    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IHashingService, BcryptHashing>();

            return services;
        }
    }
}
