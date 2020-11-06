using Autofac;
using eWAN.Application.Services;
using eWAN.Infrastructure.Database;
using eWAN.Infrastructure.Database.Repositories;
using eWAN.Domains.User;
using eWAN.Domains.Role;
using eWAN.Domains.Application;
using eWAN.Domains.Course;
using eWAN.Domains.EnrolledProgram;
using eWAN.Domains.EnrolledSubject;
using eWAN.Domains.Program;
using eWAN.Domains.Room;
using eWAN.Domains.Section;
using eWAN.Domains.Semester;
using eWAN.Domains.Session;
using eWAN.Domains.Subject;
using Microsoft.EntityFrameworkCore;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;

namespace eWAN.Modules.Autofac
{

    public static class PersistenceExtensions
    {
        public static ContainerBuilder AddPersistence(this ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var options = new DbContextOptionsBuilder<EwanContext>();
                options.UseLazyLoadingProxies();
                return new EwanContext(options.Options);
            }).AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().EnableInterfaceInterceptors().InterceptedBy(typeof(AsyncDeterminationInterceptor));

            // Repositories
            builder.RegisterType<UserRepository>().As<IUserRepository>().EnableInterfaceInterceptors().InterceptedBy(typeof(AsyncDeterminationInterceptor));
            builder.RegisterType<RoleRepository>().As<IRoleRepository>().EnableInterfaceInterceptors().InterceptedBy(typeof(AsyncDeterminationInterceptor));
            builder.RegisterType<ApplicationRepository>().As<IApplicationRepository>().EnableInterfaceInterceptors().InterceptedBy(typeof(AsyncDeterminationInterceptor));
            builder.RegisterType<CourseRepository>().As<ICourseRepository>().EnableInterfaceInterceptors().InterceptedBy(typeof(AsyncDeterminationInterceptor));
            builder.RegisterType<EnrolledProgramRepository>().As<IEnrolledProgramRepository>().EnableInterfaceInterceptors().InterceptedBy(typeof(AsyncDeterminationInterceptor));
            builder.RegisterType<EnrolledSubjectRepository>().As<IEnrolledSubjectRepository>().EnableInterfaceInterceptors().InterceptedBy(typeof(AsyncDeterminationInterceptor));
            builder.RegisterType<ProgramRepository>().As<IProgramRepository>().EnableInterfaceInterceptors().InterceptedBy(typeof(AsyncDeterminationInterceptor));
            builder.RegisterType<RoomRepository>().As<IRoomRepository>().EnableInterfaceInterceptors().InterceptedBy(typeof(AsyncDeterminationInterceptor));
            builder.RegisterType<SectionRepository>().As<ISectionRepository>().EnableInterfaceInterceptors().InterceptedBy(typeof(AsyncDeterminationInterceptor));
            builder.RegisterType<SemesterRepository>().As<ISemesterRepository>().EnableInterfaceInterceptors().InterceptedBy(typeof(AsyncDeterminationInterceptor));
            builder.RegisterType<SessionRepository>().As<ISessionRepository>().EnableInterfaceInterceptors().InterceptedBy(typeof(AsyncDeterminationInterceptor));
            builder.RegisterType<SubjectRepository>().As<ISubjectRepository>().EnableInterfaceInterceptors().InterceptedBy(typeof(AsyncDeterminationInterceptor));

            // Factories
            builder.RegisterType<EntityFactory>().As<IUserFactory>().EnableInterfaceInterceptors().InterceptedBy(typeof(AsyncDeterminationInterceptor));
            builder.RegisterType<EntityFactory>().As<IRoleFactory>().EnableInterfaceInterceptors().InterceptedBy(typeof(AsyncDeterminationInterceptor));
            builder.RegisterType<EntityFactory>().As<IApplicationFactory>().EnableInterfaceInterceptors().InterceptedBy(typeof(AsyncDeterminationInterceptor));
            builder.RegisterType<EntityFactory>().As<ICourseFactory>().EnableInterfaceInterceptors().InterceptedBy(typeof(AsyncDeterminationInterceptor));
            builder.RegisterType<EntityFactory>().As<IEnrolledProgramFactory>().EnableInterfaceInterceptors().InterceptedBy(typeof(AsyncDeterminationInterceptor));
            builder.RegisterType<EntityFactory>().As<IEnrolledSubjectFactory>().EnableInterfaceInterceptors().InterceptedBy(typeof(AsyncDeterminationInterceptor));
            builder.RegisterType<EntityFactory>().As<IProgramFactory>().EnableInterfaceInterceptors().InterceptedBy(typeof(AsyncDeterminationInterceptor));
            builder.RegisterType<EntityFactory>().As<IRoomFactory>().EnableInterfaceInterceptors().InterceptedBy(typeof(AsyncDeterminationInterceptor));
            builder.RegisterType<EntityFactory>().As<ISectionFactory>().EnableInterfaceInterceptors().InterceptedBy(typeof(AsyncDeterminationInterceptor));
            builder.RegisterType<EntityFactory>().As<ISemesterFactory>().EnableInterfaceInterceptors().InterceptedBy(typeof(AsyncDeterminationInterceptor));
            builder.RegisterType<EntityFactory>().As<ISessionFactory>().EnableInterfaceInterceptors().InterceptedBy(typeof(AsyncDeterminationInterceptor));
            builder.RegisterType<EntityFactory>().As<ISubjectFactory>().EnableInterfaceInterceptors().InterceptedBy(typeof(AsyncDeterminationInterceptor));
            builder.RegisterType<EntityFactory>().As<IRoomFactory>().EnableInterfaceInterceptors().InterceptedBy(typeof(AsyncDeterminationInterceptor));

            builder.RegisterType<SeedData>().AsSelf();

            return builder;
        }
    }
}
