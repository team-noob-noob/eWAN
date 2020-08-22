using Microsoft.Extensions.DependencyInjection;

namespace eWAN.WebApi.Modules
{
    using UseCases.Register;
    using UseCases.LogIn;
    using UseCases.StudentApplication;
    using UseCases.ApplicationJurying;
    using UseCases.CreateSubject;
    using Application.Boundaries.Register;
    using Application.Boundaries.LogIn;
    using Application.Boundaries.StudentApplication;
    using Application.Boundaries.ApplicationJurying;
    using Application.Boundaries.CreateSubject;

    public static class UserInterfaceExtensions
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            services.AddScoped<RegisterPresenter, RegisterPresenter>();
            services.AddScoped<IRegisterOutputPort>(x => x.GetRequiredService<RegisterPresenter>());

            services.AddScoped<LogInPresenter, LogInPresenter>();
            services.AddScoped<ILogInOutputPort>(x => x.GetRequiredService<LogInPresenter>());

            services.AddScoped<StudentApplicationPresenter, StudentApplicationPresenter>();
            services.AddScoped<IStudentApplicationOutputPort>(x => x.GetRequiredService<StudentApplicationPresenter>());

            services.AddScoped<ApplicationJuryingPresenter, ApplicationJuryingPresenter>();
            services.AddScoped<IApplicationJuryingOutputPort>(x => x.GetRequiredService<ApplicationJuryingPresenter>());

            services.AddScoped<CreateSubjectPresenter, CreateSubjectPresenter>();
            services.AddScoped<ICreateSubjectOutputPort>(x => x.GetRequiredService<CreateSubjectPresenter>());

            return services;
        }
    }
}