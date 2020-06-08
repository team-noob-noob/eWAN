using Microsoft.Extensions.DependencyInjection;

namespace eWAN.WebApi.Modules
{
    using Application.Services;
    using Domains.User;
    using Domains.Role;
    using Infrastructure.Database;
    using Infrastructure.Database.Repositories;

    public static class PersistenceExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<EwanContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();

            services.AddScoped<IUserFactory, EntityFactory>();
            services.AddScoped<IRoleFactory, EntityFactory>();

            return services;
        }
    }
}
