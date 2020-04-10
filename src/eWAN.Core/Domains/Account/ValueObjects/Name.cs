using System.Collections.Generic;

namespace eWAN.Core.Domains.Account
{
    public class Name : ValueObject
    {
        public string firstName { get; private set; }
        public string middleName { get; private set; }
        public string lastName { get; private set; }

        private Name()
        {}
        public Name(
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
}
