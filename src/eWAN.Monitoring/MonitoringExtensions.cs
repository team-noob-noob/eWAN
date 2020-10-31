using Autofac;

namespace eWAN.Monitoring
{
    public static class MonitoringExtensions
    {
        public static ContainerBuilder AddMonitoring(this ContainerBuilder builder)
        {
            builder.Register(_ => new SpanMonitoring());
            return builder;
        }
    }
}