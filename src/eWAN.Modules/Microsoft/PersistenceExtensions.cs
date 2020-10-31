using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using eWAN.Application.Services;
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
using eWAN.Infrastructure.Database;
using eWAN.Infrastructure.Database.Repositories;

namespace eWAN.Modules.Microsoft
{
    public static class PersistenceExtensions
    {
        [Obsolete("Replace with eWAN.Modules.Autofac.PersistenceExtensions.AddPersistence()", true)]
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
