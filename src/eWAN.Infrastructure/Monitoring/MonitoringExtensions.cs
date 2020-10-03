using Microsoft.Extensions.DependencyInjection;
using AspectCore.Extensions.DependencyInjection;
using AspectCore.Configuration;

namespace eWAN.Infrastructure.Monitoring
{
    public static class MonitoringExtensions
    {
        public static IServiceCollection AddMonitoring(this IServiceCollection services)
        {
            services.ConfigureDynamicProxy(config => config.Interceptors.AddTyped<CountMonitoringAttribute>());

            return services;
        }
    }
}
