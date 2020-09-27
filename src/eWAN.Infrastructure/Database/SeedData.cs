using eWAN.Infrastructure.Database.Entities;
using System.Collections.Generic;
using eWAN.Infrastructure.Hashing;
using System;

namespace eWAN.Infrastructure.Database
{
    public class SeedData
    {
        public SeedData(EwanContext context)
        {
            this._context = context;
        }
        private EwanContext _context { get; }

        public static readonly User User1 = new Bogus.Faker<User>()
            .RuleFor(o => o.FirstName, f => f.Person.FirstName)
            .RuleFor(o => o.MiddleName, f => f.Person.LastName)
            .RuleFor(o => o.LastName, f => f.Person.LastName)
            .RuleFor(o => o.Address, f => f.Address.FullAddress())
            .RuleFor(o => o.PhoneNumber, f => f.Phone.PhoneNumber())
            .RuleFor(o => o.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
            .RuleFor(o => o.Username, (f, u) => f.Internet.UserName(u.FirstName, u.LastName))
            .RuleFor(o => o.Password, f => new BcryptHashing().Hash(f.Internet.Password(memorable: true)));
        
        public static readonly User User2 = new Bogus.Faker<User>()
            .RuleFor(o => o.FirstName, f => f.Person.FirstName)
            .RuleFor(o => o.MiddleName, f => f.Person.LastName)
            .RuleFor(o => o.LastName, f => f.Person.LastName)
            .RuleFor(o => o.Address, f => f.Address.FullAddress())
            .RuleFor(o => o.PhoneNumber, f => f.Phone.PhoneNumber())
            .RuleFor(o => o.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
            .RuleFor(o => o.Username, (f, u) => f.Internet.UserName(u.FirstName, u.LastName))
            .RuleFor(o => o.Password, f => new BcryptHashing().Hash(f.Internet.Password(memorable: true)));

        public static readonly Student Student = new Student(User1);

        public static readonly Room Room = new Bogus.Faker<Room>()
            .RuleFor(o => o.Schedule, _ => new List<Domains.Session.ISession>())
            .RuleFor(o => o.Id, f => f.Random.Number(100, 999).ToString())
            .RuleFor(o => o.Name, (_, o) => "Room " + o.Id)
            .RuleFor(o => o.Address, f => f.Address.ToString());

        public static readonly Program Program = new Bogus.Faker<Program>()
            .RuleFor(o => o.Title, f => $"Bachelor of Science in {f.Hacker.Abbreviation()} {f.Hacker.Noun()}")
            .RuleFor(o => o.Code, f => "BS" + f.Hacker.Abbreviation())
            .RuleFor(o => o.Description, (f, o) => f.Rant.Review(o.Title));

        public static readonly Course Course = new Bogus.Faker<Course>()
            .RuleFor(o => o.Id, f => f.Hacker.Abbreviation())
            .RuleFor(o => o.Title, f => f.Hacker.Adjective() + " " + f.Hacker.Noun())
            .RuleFor(o => o.Description, (f, o) => f.Rant.Review(o.Title))
            .RuleFor(o => o.AssignedProgram, _ => Program);

        public static readonly Session FirstSession = new Bogus.Faker<Session>()
            .RuleFor(o => o.Day, f => f.PickRandom<System.DayOfWeek>())
            .RuleFor(o => o.StartTime, _ => new System.TimeSpan(7, 30, 00))
            .RuleFor(o => o.EndTime, (_, o) => o.StartTime.Add(new System.TimeSpan(0, 1, 0)))
            .RuleFor(o => o.Room, _ => Room)
            .RuleFor(o => o.Instructor, _ => User2)
            .RuleFor(o => o.Type, f => f.PickRandom<eWAN.Domains.Session.SessionType>());

        public static readonly Session SecondSession = new Bogus.Faker<Session>()
            .RuleFor(o => o.Day, f => f.PickRandom<System.DayOfWeek>())
            .RuleFor(o => o.StartTime, _ => new System.TimeSpan(7, 30, 00))
            .RuleFor(o => o.EndTime, (_, o) => o.StartTime.Add(new System.TimeSpan(0, 1, 0)))
            .RuleFor(o => o.Room, _ => Room)
            .RuleFor(o => o.Instructor, _ => User2)
            .RuleFor(o => o.Type, f => f.PickRandom<eWAN.Domains.Session.SessionType>());
        
        public static readonly Subject Subject = 
            new Subject(Course, new List<Domains.Session.ISession>(new []{FirstSession, SecondSession}));

        public static readonly Semester Semester = new Semester(
            "1st Semester (AY 2020 - 2020)" + new Random().NewString(),
            new System.DateTime(),
            new System.DateTime() + new System.TimeSpan(120, 0, 0, 0),
            new List<Domains.Subject.ISubject>(new []{Subject})
        );

        public void Seed()
        {
            this._context.Users.Add(User1);
            this._context.Users.Add(User2);
            this._context.Students.Add(Student);
            this._context.Rooms.Add(Room);
            this._context.Programs.Add(Program);
            this._context.Courses.Add(Course);
            this._context.Sessions.Add(FirstSession);
            this._context.Sessions.Add(SecondSession);
            this._context.Subjects.Add(Subject);
            this._context.EnrolledPrograms.Add(new EnrolledProgram(Student, Program));
            this._context.EnrolledSubjects.Add(new EnrolledSubject(Student, Subject){grade = ""});
            this._context.Semesters.Add(Semester);
            this._context.Sections.Add(new Section("BSIT - 1B - 2077" + new Random().NewString(), new List<eWAN.Domains.Student.IStudent>(new []{Student})));
            this._context.SaveChanges();
        }
    }
}
