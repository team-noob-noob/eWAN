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
using eWAN.Monitoring;

namespace eWAN.Modules.Autofac
{
    public static class UseCaseExtensions
    {
        public static ContainerBuilder AddUseCases(this ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationJuryingUseCase>().As<IApplicationJuryingUseCase>().EnableInterfaceInterceptors().InterceptedBy(typeof(SpanMonitor));
            builder.RegisterType<CreateCourseUseCase>().As<ICreateCourseUseCase>().EnableInterfaceInterceptors().InterceptedBy(typeof(SpanMonitor));
            builder.RegisterType<CreateProgramUseCase>().As<ICreateProgramUseCase>().EnableInterfaceInterceptors().InterceptedBy(typeof(SpanMonitor));
            builder.RegisterType<CreateRoomUseCase>().As<ICreateRoomUseCase>().EnableInterfaceInterceptors().InterceptedBy(typeof(SpanMonitor));
            builder.RegisterType<CreateSubjectUseCase>().As<ICreateSubjectUseCase>().EnableInterfaceInterceptors().InterceptedBy(typeof(SpanMonitor));
            builder.RegisterType<LogInUseCase>().As<ILogInUseCase>().EnableInterfaceInterceptors().InterceptedBy(typeof(SpanMonitor));
            builder.RegisterType<RegisterUseCase>().As<IRegisterUseCase>().EnableInterfaceInterceptors().InterceptedBy(typeof(SpanMonitor));
            builder.RegisterType<StudentApplicationUseCase>().As<IStudentApplicationUseCase>().EnableInterfaceInterceptors().InterceptedBy(typeof(SpanMonitor));
            return builder;
        }
    }
}
