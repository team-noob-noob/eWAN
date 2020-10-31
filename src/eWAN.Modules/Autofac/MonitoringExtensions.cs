using Autofac;
using eWAN.Monitoring;

namespace eWAN.Modules.Autofac
{
    public static class MonitoringExtensions
    {
        public static ContainerBuilder AddMonitoring(this ContainerBuilder builder)
        {
            builder.Register(_ => new SpanMonitor());
            return builder;
        }
    }
}