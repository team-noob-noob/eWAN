using Autofac;
using eWAN.Infrastructure.Hashing;
using eWAN.Application.Services;
using eWAN.Domains.Session;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;

namespace eWAN.Modules.Autofac
{
    public static class ServicesExtensions
    {
        public static ContainerBuilder AddServices(this ContainerBuilder builder)
        {
            builder.RegisterType<BcryptHashing>().As<IHashingService>().EnableInterfaceInterceptors().InterceptedBy(typeof(AsyncDeterminationInterceptor));
            builder.RegisterType<SessionFitService>().As<ISessionFitService>().EnableInterfaceInterceptors().InterceptedBy(typeof(AsyncDeterminationInterceptor));
            return builder;
        }
    }
}
