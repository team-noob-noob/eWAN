using System.Collections.Generic;
using eWAN.Domains.EnrolledProgram;
using eWAN.Domains.EnrolledSubject;
using eWAN.Domains.Role;
using eWAN.Domains.Section;

namespace eWAN.Domains.User
{
    public abstract class User : BaseEntity, IUser
    {
        public abstract string Username { get; set; }
        public abstract string Password { get; set; }


        public abstract string Id { get; protected set; }

        public abstract string Email { get; set; }

        public abstract string PhoneNumber { get; set; }

        public abstract string FirstName { get; set; }

        public abstract string MiddleName { get; set; }

        public abstract string LastName { get; set; }

        public abstract string Address { get; set; }
        public virtual List<IEnrolledSubject> EnrolledSubjects { get; set; } = new List<IEnrolledSubject>();
        public virtual List<IEnrolledProgram> EnrolledPrograms { get; set; } = new List<IEnrolledProgram>();
        public virtual List<IRole> AssignedRoles { get; set; } = new List<IRole>();
        public virtual ISection? AssignedSection { get; set; }
    }
}
