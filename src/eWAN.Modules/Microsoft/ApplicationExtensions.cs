using System;
using Microsoft.Extensions.DependencyInjection;
using eWAN.Application.Boundaries.Register;
using eWAN.Application.Boundaries.LogIn;
using eWAN.Application.Boundaries.ApplicationJurying;
using eWAN.Application.Boundaries.StudentApplication;
using eWAN.Application.Boundaries.CreateSubject;
using eWAN.Application.Boundaries.CreateProgram;
using eWAN.Application.Boundaries.CreateRoom;
using eWAN.Application.Boundaries.CreateCourse;
using eWAN.Application.UseCases;

namespace eWAN.Modules.Microsoft
{
    public static class ApplicationExtensions
    {
        [Obsolete("Replace with eWAN.Modules.Autofac.PersistenceExtensions.AddPersistence()", true)]
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
