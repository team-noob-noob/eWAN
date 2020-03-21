namespace eWAN.Core.Domains.ValueObjects.Identity
{
    using eWAN.Core.Domains.ValueObject.Base;

    public class UserDetails : ValueObject
    {
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }

        protected IEnumerable<object> GetAtomicValues()
        {
            yield return firstName;
            yield return middleName;
            yield return lastName;
        }
    }

    public class UserContacts : ValueObject
    {
        public string emailAddress { get; set; }
        public string mobileNumber { get; set; }
        public string homeAddress { get; set; }

        protected IEnumerable<object> GetAtomicValues()
        {
            yield return emailAddress;
            yield return mobileNumber;
            yield return homeAddress;
        }
    }

    public class UserGuardian : ValueObject
    {
        public string name { get; set; }
        public string mobileNumber { get; set; }

        protected IEnumerable<object> GetAtomicValues()
        {
            yield return name;
            yield return mobileNumber;
        }
    }
}
