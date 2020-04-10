using System.Collections.Generic;

namespace eWAN.Core.Domains.Account
{
    public class UserGuardian : ValueObject
    {
        public string name { get; private set; }
        public PhoneNumber mobileNumber { get; private set; }

        private UserGuardian()
        {}

        public UserGuardian(
            string name,
            PhoneNumber mobileNumber
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
