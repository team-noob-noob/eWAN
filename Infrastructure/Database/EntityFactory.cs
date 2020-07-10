namespace eWAN.Infrastructure.Database
{
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
    using Role = Entities.Role;
    using User = Entities.User;
    using Application = Entities.Application;
    using Course = Entities.Course;
    using EnrolledProgram = Entities.EnrolledProgram;
    using EnrolledSubject = Entities.EnrolledSubject;
    using Room = Entities.Room;
    using Section = Entities.Section;
    using Semester = Entities.Semester;
    using Session = Entities.Session;
    using System.Collections.Generic;
    using System;

    public class EntityFactory : 
    IUserFactory, 
    IRoleFactory, 
    IApplicationFactory,
    ICourseFactory,
    IEnrolledProgramFactory,
    IEnrolledSubjectFactory,
    IRoomFactory,
    ISectionFactory,
    ISemesterFactory,
    ISessionFactory
    {
        public ISemester AddSemester(string Id, DateTime Start, DateTime End, bool IsOpenForEnrollment, List<ISubject> OpenCourses) =>
            new Semester(Id, Start, End, OpenCourses, IsOpenForEnrollment);

        public ISession AddSession(DayOfWeek day, DateTime time, IRoom room, IUser instructor, SessionType type) =>
            new Session(day, time, room, instructor, type);

        public IApplication NewApplication(IUser applicant) => new Application(applicant);

        public ICourse NewCourse(string Id, string Title, string Description, List<ICourse> Prerequisites) =>
            new Course(Id, Title, Description, Prerequisites);

        public IEnrolledProgram NewEnrolledProgram(IUser student, IProgram program) =>
            new EnrolledProgram(student, program);

        public IEnrolledSubject NewEnrolledSubject(IUser student, ISubject subject, string grade = null) =>
            new EnrolledSubject(student, subject, grade);

        public IRole NewRole(IUser user, UserRole role = UserRole.StudentApplicant) => new Role(user, role);

        public IRoom NewRoom(string Id, string Name, string Address) => new Room(Id, Name, Address);

        public ISection NewSection(string Name, List<IUser> Students) => new Section(Name, Students);

        public IUser NewUser(
            string Username,
            string Password, 

            string Email, 
            string PhoneNumber, 

            string FirstName,
            string MiddleName,
            string LastName,

            string Address) => new User(
                Username, 
                Password,
                Email,
                PhoneNumber,
                FirstName,
                MiddleName,
                LastName,
                Address);
    }
}
