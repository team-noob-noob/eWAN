using Autofac;
using eWAN.Infrastructure.Hashing;
using eWAN.Application.Services;
using eWAN.Domains.Session;

namespace eWAN.Modules.Autofac
{
    public static class ServicesExtensions
    {
        public static ContainerBuilder AddServices(this ContainerBuilder builder)
        {
            builder.RegisterType<BcryptHashing>().As<IHashingService>();
            builder.RegisterType<SessionFitService>().As<ISessionFitService>();
            return builder;
        }
    }
}
