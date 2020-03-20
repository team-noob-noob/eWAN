namespace eWAN.Core.Domains.ValueObjects.Identity
{
    using eWAN.Core.Domains.ValueObject.Base;

    public class UserDetails : ValueObject
    {
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
    }

    public class UserContacts : ValueObject
    {
        public string emailAddress { get; set; }
        public string mobileNumber { get; set; }
        public string homeAddress { get; set; }
    }

    public class UserGuardian : ValueObject
    {
        public string name { get; set; }
        public string contact { get; set; }
    }
}
