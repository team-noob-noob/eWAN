using System.Collections.Generic;
using eWAN.Domains.Role;
using eWAN.Domains.Student;

namespace eWAN.Domains.User
{
    /// <summary>
    /// Holds all of the Personally Identifiable Information
    /// </summary>
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
        List<IRole> AssignedRoles { get; set; }
        IStudent? StudentProfile { get; set; }
    }
}
