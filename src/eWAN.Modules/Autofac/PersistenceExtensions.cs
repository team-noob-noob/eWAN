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

namespace eWAN.Modules.Autofac
{

    public static class PersistenceExtensions
    {
        public static ContainerBuilder AddPersistence(this ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var options = new DbContextOptionsBuilder<EwanContext>();
                return new EwanContext(options.Options);
            }).AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            // Repositories
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<RoleRepository>().As<IRoleRepository>();
            builder.RegisterType<ApplicationRepository>().As<IApplicationRepository>();
            builder.RegisterType<CourseRepository>().As<ICourseRepository>();
            builder.RegisterType<EnrolledProgramRepository>().As<IEnrolledProgramRepository>();
            builder.RegisterType<EnrolledSubjectRepository>().As<IEnrolledSubjectRepository>();
            builder.RegisterType<ProgramRepository>().As<IProgramRepository>();
            builder.RegisterType<RoomRepository>().As<IRoomRepository>();
            builder.RegisterType<SectionRepository>().As<ISectionRepository>();
            builder.RegisterType<SemesterRepository>().As<ISemesterRepository>();
            builder.RegisterType<SessionRepository>().As<ISessionRepository>();
            builder.RegisterType<SubjectRepository>().As<ISubjectRepository>();

            // Factories
            builder.RegisterType<EntityFactory>().As<IUserFactory>();
            builder.RegisterType<EntityFactory>().As<IRoleFactory>();
            builder.RegisterType<EntityFactory>().As<IApplicationFactory>();
            builder.RegisterType<EntityFactory>().As<ICourseFactory>();
            builder.RegisterType<EntityFactory>().As<IEnrolledProgramFactory>();
            builder.RegisterType<EntityFactory>().As<IEnrolledSubjectFactory>();
            builder.RegisterType<EntityFactory>().As<IProgramFactory>();
            builder.RegisterType<EntityFactory>().As<IRoomFactory>();
            builder.RegisterType<EntityFactory>().As<ISectionFactory>();
            builder.RegisterType<EntityFactory>().As<ISemesterFactory>();
            builder.RegisterType<EntityFactory>().As<ISessionFactory>();
            builder.RegisterType<EntityFactory>().As<ISubjectFactory>();
            builder.RegisterType<EntityFactory>().As<IRoomFactory>();

            builder.RegisterType<SeedData>().AsSelf();

            return builder;
        }
    }
}
