
namespace eWAN.Core.Domains.Identity
{
    using eWAN.Core.Domains.Base;

    public class User : BaseEntity
    {
        public string username { get; protected set; }
        public string password { get; protected set; }
    }

    public class UserDetails : BaseEntity
    {
        public string firstName { get; protected set; }
        public string middleName { get; protected set; }
        public string lastName { get; protected set; }
    }

    public class UserContacts : BaseEntity
    {
        public string emailAddress { get; protected set; }
        public string mobileNumber { get; protected set; }
        public string homeAddress { get; protected set; }
    }
}
