using eWAN.Core.Domains.Entities.Base;
using eWAN.Core.Domains.Enums;

namespace eWAN.Core.Domains.Entities 
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public string EmergencyContact_Name { get; set; }
        public string EmergencyContact_PhoneNumber { get; set; }

        public string Email { get; set; }
        public UserRoleType Role { get; set; }
    }
}
