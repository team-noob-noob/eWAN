using Autofac;
using eWAN.Monitoring;
using Castle.DynamicProxy;

namespace eWAN.Modules.Autofac
{
    public static class MonitoringExtensions
    {
        public static ContainerBuilder AddMonitoring(this ContainerBuilder builder)
        {
            builder.Register(_ => new SpanMonitor());
            builder.Register(_ => new AsyncDeterminationInterceptor(new SpanMonitor()));
            return builder;
        }
    }
}