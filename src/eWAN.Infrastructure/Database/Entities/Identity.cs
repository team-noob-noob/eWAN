using Microsoft.AspNetCore.Identity;

namespace eWAN.Infrastructure.Database.Entities
{
    public class Identity : IdentityUser
    {
        public Identity()
        {}

        [ProtectedPersonalData]
        public string FirstName { get; set; }

        [ProtectedPersonalData]
        public string MiddleName { get; set; }

        [ProtectedPersonalData]
        public string LastName { get; set; }

        [ProtectedPersonalData]
        public string HomeAddress { get; set; }
    }
}
