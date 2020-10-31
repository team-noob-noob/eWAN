using System;
using Microsoft.Extensions.DependencyInjection;
using eWAN.Domains.Session;
using eWAN.Application.Services;
using eWAN.Infrastructure.Hashing;

namespace eWAN.Modules.Microsoft
{
    public static class ServiceExtensions
    {
        [Obsolete("Replace with eWAN.Modules.Autofac.PersistenceExtensions.AddPersistence()", true)]
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IHashingService, BcryptHashing>();
            services.AddScoped<ISessionFitService, SessionFitService>();

            return services;
        }
    }
}
