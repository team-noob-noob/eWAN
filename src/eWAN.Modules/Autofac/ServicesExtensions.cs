using Autofac;
using eWAN.Infrastructure.Hashing;
using eWAN.Application.Services;
using eWAN.Domains.Session;
using eWAN.Monitoring;
using Autofac.Extras.DynamicProxy;

namespace eWAN.Modules.Autofac
{
    public static class ServicesExtensions
    {
        public static ContainerBuilder AddServices(this ContainerBuilder builder)
        {
            builder.RegisterType<BcryptHashing>().As<IHashingService>().EnableInterfaceInterceptors().InterceptedBy(typeof(SpanMonitor));
            builder.RegisterType<SessionFitService>().As<ISessionFitService>().EnableInterfaceInterceptors().InterceptedBy(typeof(SpanMonitor));
            return builder;
        }
    }
}
