using Microsoft.Extensions.DependencyInjection;

namespace eWAN.WebApi.Modules
{
    using Application.Boundaries.Register;
    using Application.Boundaries.LogIn;
    using Application.Boundaries.ApplicationJurying;
    using Application.Boundaries.StudentApplication;
    using Application.UseCases;

    public static class ApplicationExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IRegisterUseCase, RegisterUseCase>();
            services.AddScoped<ILogInUseCase, LogInUseCase>();
            services.AddScoped<IApplicationJuryingUseCase, ApplicationJuryingUseCase>();
            services.AddScoped<IStudentApplicationUseCase, StudentApplicationUseCase>();
            return services;
        }
    }
}
