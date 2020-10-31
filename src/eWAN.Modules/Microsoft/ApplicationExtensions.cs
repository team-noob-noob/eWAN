using Microsoft.Extensions.DependencyInjection;

namespace eWAN.Modules.Microsoft
{
    using Application.Boundaries.Register;
    using Application.Boundaries.LogIn;
    using Application.Boundaries.ApplicationJurying;
    using Application.Boundaries.StudentApplication;
    using Application.Boundaries.CreateSubject;
    using Application.Boundaries.CreateProgram;
    using Application.Boundaries.CreateRoom;
    using Application.Boundaries.CreateCourse;
    using Application.UseCases;

    public static class ApplicationExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IRegisterUseCase, RegisterUseCase>();
            services.AddScoped<ILogInUseCase, LogInUseCase>();
            services.AddScoped<IApplicationJuryingUseCase, ApplicationJuryingUseCase>();
            services.AddScoped<IStudentApplicationUseCase, StudentApplicationUseCase>();
            services.AddScoped<ICreateSubjectUseCase, CreateSubjectUseCase>();
            services.AddScoped<ICreateProgramUseCase, CreateProgramUseCase>();
            services.AddScoped<ICreateRoomUseCase, CreateRoomUseCase>();
            services.AddScoped<ICreateCourseUseCase, CreateCourseUseCase>();
            return services;
        }
    }
}
