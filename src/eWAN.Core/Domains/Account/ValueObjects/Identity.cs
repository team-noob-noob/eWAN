using System.Collections.Generic;

namespace eWAN.Core.Domains.Account
{
    public class UserDetails : ValueObject
    {
        public string firstName { get; private set; }
        public string middleName { get; private set; }
        public string lastName { get; private set; }

        private UserDetails()
        {}
        public UserDetails(
            string firstName,
            string middleName,
            string lastName
        )
        {
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
        }

        public string GetProperFullName()
        {
            return $"{firstName} ${middleName} ${lastName}";
        }

        public string GetFormalFullName()
        {
            return $"{lastName}, {firstName} {middleName}";
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return firstName;
            yield return middleName;
            yield return lastName;
        }
    }

    public class UserContacts : ValueObject
    {
        public string emailAddress { get; private set; }
        public PhoneNumber mobileNumber { get; private set; }
        public Address homeAddress { get; private set; }

        private UserContacts()
        {}
        
        public UserContacts(
            string emailAddress,
            PhoneNumber mobileNumber,
            Address homeAddress
        )
        {
            this.emailAddress = emailAddress;
            this.mobileNumber = mobileNumber;
            this.homeAddress = homeAddress;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return emailAddress;
            yield return mobileNumber;
            yield return homeAddress;
        }
    }

    public class UserGuardian : ValueObject
    {
        public string name { get; private set; }
        public string mobileNumber { get; private set; }

        private UserGuardian()
        {}

        public UserGuardian(
            string name,
            string mobileNumber
        )
        {
            this.name = name;
            this.mobileNumber = mobileNumber;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return name;
            yield return mobileNumber;
        }
    }
}
