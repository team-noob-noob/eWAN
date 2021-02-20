using Microsoft.Extensions.DependencyInjection;

namespace eWAN.WebApi.Modules
{
    using UseCases.Register;
    using UseCases.StudentApplication;
    using UseCases.ApplicationJurying;
    using UseCases.CreateProgram;
    using UseCases.CreateSubject;
    using UseCases.CreateRoom;
    using UseCases.CreateCourse;
    using Application.Boundaries.Register;
    using Application.Boundaries.LogIn;
    using Application.Boundaries.StudentApplication;
    using Application.Boundaries.ApplicationJurying;
    using Application.Boundaries.CreateSubject;
    using Application.Boundaries.CreateProgram;
    using Application.Boundaries.CreateRoom;
    using Application.Boundaries.CreateCourse;

    public static class UserInterfaceExtensions
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            services.AddScoped<RegisterPresenter, RegisterPresenter>();
            services.AddScoped<IRegisterOutputPort>(x => x.GetRequiredService<RegisterPresenter>());

            services.AddScoped<StudentApplicationPresenter, StudentApplicationPresenter>();
            services.AddScoped<IStudentApplicationOutputPort>(x => x.GetRequiredService<StudentApplicationPresenter>());

            services.AddScoped<ApplicationJuryingPresenter, ApplicationJuryingPresenter>();
            services.AddScoped<IApplicationJuryingOutputPort>(x => x.GetRequiredService<ApplicationJuryingPresenter>());

            services.AddScoped<CreateSubjectPresenter, CreateSubjectPresenter>();
            services.AddScoped<ICreateSubjectOutputPort>(x => x.GetRequiredService<CreateSubjectPresenter>());

            services.AddScoped<CreateProgramPresenter, CreateProgramPresenter>();
            services.AddScoped<ICreateProgramOutputPort>(x => x.GetRequiredService<CreateProgramPresenter>());

            services.AddScoped<CreateRoomPresenter, CreateRoomPresenter>();
            services.AddScoped<ICreateRoomOutputPort>(x => x.GetRequiredService<CreateRoomPresenter>());

            services.AddScoped<CreateCoursePresenter, CreateCoursePresenter>();
            services.AddScoped<ICreateCourseOutputPort>(x => x.GetRequiredService<CreateCoursePresenter>());

            return services;
        }
    }
}
