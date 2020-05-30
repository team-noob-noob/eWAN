using Microsoft.Extensions.DependencyInjection;

namespace eWAN.WebApi.Modules
{
    using Application.Boundaries.Register;
    using Application.UseCases;

    public static class ApplicationExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IRegisterUseCase, RegisterUseCase>();

            return services;
        }
    }
}
