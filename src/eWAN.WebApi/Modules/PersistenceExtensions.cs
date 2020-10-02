using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace eWAN.WebApi.Modules
{
    using Application.Services;
    using Domains.User;
    using Domains.Role;
    using Domains.Application;
    using Domains.Course;
    using Domains.EnrolledProgram;
    using Domains.EnrolledSubject;
    using Domains.Program;
    using Domains.Room;
    using Domains.Section;
    using Domains.Semester;
    using Domains.Session;
    using Domains.Subject;
    using Infrastructure.Database;
    using Infrastructure.Database.Repositories;

    public static class PersistenceExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<EwanContext>(options => options.UseLazyLoadingProxies(), ServiceLifetime.Transient, ServiceLifetime.Transient);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IApplicationRepository, ApplicationRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IEnrolledProgramRepository, EnrolledProgramRepository>();
            services.AddScoped<IEnrolledSubjectRepository, EnrolledSubjectRepository>();
            services.AddScoped<IProgramRepository, ProgramRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<ISectionRepository, SectionRepository>();
            services.AddScoped<ISemesterRepository, SemesterRepository>();
            services.AddScoped<ISessionRepository, SessionRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();

            services.AddScoped<IUserFactory, EntityFactory>();
            services.AddScoped<IRoleFactory, EntityFactory>();
            services.AddScoped<IApplicationFactory, EntityFactory>();
            services.AddScoped<ICourseFactory, EntityFactory>();
            services.AddScoped<IEnrolledProgramFactory, EntityFactory>();
            services.AddScoped<IEnrolledSubjectFactory, EntityFactory>();
            services.AddScoped<IProgramFactory, EntityFactory>();
            services.AddScoped<IRoomFactory, EntityFactory>();
            services.AddScoped<ISectionFactory, EntityFactory>();
            services.AddScoped<ISemesterFactory, EntityFactory>();
            services.AddScoped<ISessionFactory, EntityFactory>();
            services.AddScoped<ISubjectFactory, EntityFactory>();
            services.AddScoped<IRoomFactory, EntityFactory>();

            services.AddSingleton<SeedData>();

            return services;
        }
    }
}
