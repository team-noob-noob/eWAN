using Microsoft.Extensions.DependencyInjection;

namespace eWAN.WebApi.Modules
{
    using UseCases.Register;
    using UseCases.LogIn;
    using Application.Boundaries.Register;
    using Application.Boundaries.LogIn;

    public static class UserInterfaceExtensions
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            services.AddScoped<RegisterPresenter, RegisterPresenter>();
            services.AddScoped<IRegisterOutputPort>(x => x.GetRequiredService<RegisterPresenter>());

            services.AddScoped<LogInPresenter, LogInPresenter>();
            services.AddScoped<ILogInOutputPort>(x => x.GetRequiredService<LogInPresenter>());

            return services;
        }
    }
}
