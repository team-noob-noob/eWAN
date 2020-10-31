using Microsoft.Extensions.DependencyInjection;

namespace eWAN.Modules.Microsoft
{
    using Domains.Session;
    using Application.Services;
    using Infrastructure.Hashing;

    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IHashingService, BcryptHashing>();
            services.AddScoped<ISessionFitService, SessionFitService>();

            return services;
        }
    }
}
