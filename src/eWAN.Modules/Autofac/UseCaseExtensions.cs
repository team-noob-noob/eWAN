using Autofac;
using Autofac.Extras.DynamicProxy;
using eWAN.Application.Boundaries.ApplicationJurying;
using eWAN.Application.Boundaries.CreateCourse;
using eWAN.Application.Boundaries.CreateProgram;
using eWAN.Application.Boundaries.CreateRoom;
using eWAN.Application.Boundaries.CreateSubject;
using eWAN.Application.Boundaries.LogIn;
using eWAN.Application.Boundaries.Register;
using eWAN.Application.Boundaries.StudentApplication;
using eWAN.Application.UseCases;
using Castle.DynamicProxy;

namespace eWAN.Modules.Autofac
{
    public static class UseCaseExtensions
    {
        public static ContainerBuilder AddUseCases(this ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationJuryingUseCase>().As<IApplicationJuryingUseCase>().EnableInterfaceInterceptors().InterceptedBy(typeof(AsyncDeterminationInterceptor));
            builder.RegisterType<CreateCourseUseCase>().As<ICreateCourseUseCase>().EnableInterfaceInterceptors().InterceptedBy(typeof(AsyncDeterminationInterceptor));
            builder.RegisterType<CreateProgramUseCase>().As<ICreateProgramUseCase>().EnableInterfaceInterceptors().InterceptedBy(typeof(AsyncDeterminationInterceptor));
            builder.RegisterType<CreateRoomUseCase>().As<ICreateRoomUseCase>().EnableInterfaceInterceptors().InterceptedBy(typeof(AsyncDeterminationInterceptor));
            builder.RegisterType<CreateSubjectUseCase>().As<ICreateSubjectUseCase>().EnableInterfaceInterceptors().InterceptedBy(typeof(AsyncDeterminationInterceptor));
            builder.RegisterType<LogInUseCase>().As<ILogInUseCase>().EnableInterfaceInterceptors().InterceptedBy(typeof(AsyncDeterminationInterceptor));
            builder.RegisterType<RegisterUseCase>().As<IRegisterUseCase>().EnableInterfaceInterceptors().InterceptedBy(typeof(AsyncDeterminationInterceptor));
            builder.RegisterType<StudentApplicationUseCase>().As<IStudentApplicationUseCase>().EnableInterfaceInterceptors().InterceptedBy(typeof(AsyncDeterminationInterceptor));
            return builder;
        }
    }
}
