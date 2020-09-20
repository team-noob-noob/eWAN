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
    using Domains.Student;
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
    using Subject = Entities.Subject;
    using Program = Entities.Program;
    using Student = Entities.Student;
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
    ISessionFactory,
    ISubjectFactory,
    IProgramFactory,
    IStudentFactory
    {
        public ISemester AddSemester(string Id, DateTime Start, DateTime End, bool IsOpenForEnrollment, List<ISubject> OpenCourses) =>
            new Semester(Id, Start, End, OpenCourses, IsOpenForEnrollment);

        public ISession AddSession(DayOfWeek day, TimeSpan startTime, TimeSpan endTime, IRoom room, IUser instructor, SessionType type) =>
            new Session(day, startTime, endTime, room, instructor, type);

        public IApplication NewApplication(IUser applicant) => new Application(applicant);

        public ICourse NewCourse(string Id, string Title, string Description, List<ICourse> Prerequisites, IProgram program) =>
            new Course(Id, Title, Description, Prerequisites, program);

        public IEnrolledProgram NewEnrolledProgram(IStudent student, IProgram program) =>
            new EnrolledProgram(student, program);

        public IEnrolledSubject NewEnrolledSubject(IStudent student, ISubject subject, string grade = null) =>
            new EnrolledSubject(student, subject, grade);

        public IProgram NewProgram(string Title, string Code, string Description, List<ICourse> Courses) =>
            new Program(Title, Code, Description, Courses);

        public IRole NewRole(IUser user, UserRole role = UserRole.StudentApplicant) => new Role(user, role);

        public IRoom NewRoom(string Id, string Name, string Address) => new Room(Id, Name, Address);

        public ISection NewSection(string Name, List<IStudent> Students) => new Section(Name, Students);

        public IStudent NewStudent(IUser details) => new Student(details);

        public ISubject NewSubject(ICourse course, List<ISession> sessions) =>
            new Subject(course, sessions);

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
