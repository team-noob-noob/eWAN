using eWAN.Domains.Student;
using eWAN.Domains.User;
using System;

namespace eWAN.Infrastructure.Database.Entities
{
    public class Student : Domains.Student.Student, IStudent
    {
        protected Student() {}
        public Student(IUser details)
        {
            this.User = details;
            this.Id = DateTime.Now.Year.ToString() + new Random().NewString(10, "0123456789");
        }

        public override string Id { get; set; }
        public string UserId { get; set; }
    }
}
