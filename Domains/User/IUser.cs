using System.Collections.Generic;

namespace eWAN.Domains.User
{
    using EnrolledSubject;
    using EnrolledProgram;
    using Role;
    using Section;

    public interface IUser : IBaseEntity
    {
        string Id { get; }

        string Username { get; set; }
        string Password { get; set; }

        string Email { get; set; }
        string PhoneNumber { get; set; }
        
        string FirstName { get; set; }
        string MiddleName { get; set; }
        string LastName { get; set; }

        string Address { get; set; }

        // Inverse Property
        List<IEnrolledSubject> EnrolledSubjects { get; set; }
        List<IEnrolledProgram> EnrolledPrograms { get; set; }
        IRole AssignedRole { get; set; }
        ISection AssignedSection { get; set; }
    }
}
