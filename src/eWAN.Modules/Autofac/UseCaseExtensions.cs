using Autofac;
using eWAN.Application.Boundaries.ApplicationJurying;
using eWAN.Application.Boundaries.CreateCourse;
using eWAN.Application.Boundaries.CreateProgram;
using eWAN.Application.Boundaries.CreateRoom;
using eWAN.Application.Boundaries.CreateSubject;
using eWAN.Application.Boundaries.LogIn;
using eWAN.Application.Boundaries.Register;
using eWAN.Application.Boundaries.StudentApplication;
using eWAN.Application.UseCases;

namespace eWAN.Modules.Autofac
{
    public static class UseCaseExtensions
    {
        public static ContainerBuilder AddUseCases(this ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationJuryingUseCase>().As<IApplicationJuryingUseCase>();
            builder.RegisterType<CreateCourseUseCase>().As<ICreateCourseUseCase>();
            builder.RegisterType<CreateProgramUseCase>().As<ICreateProgramUseCase>();
            builder.RegisterType<CreateRoomUseCase>().As<ICreateRoomUseCase>();
            builder.RegisterType<CreateSubjectUseCase>().As<ICreateSubjectUseCase>();
            builder.RegisterType<LogInUseCase>().As<ILogInUseCase>();
            builder.RegisterType<RegisterUseCase>().As<IRegisterUseCase>();
            builder.RegisterType<StudentApplicationUseCase>().As<IStudentApplicationUseCase>();
            return builder;
        }
    }
}
