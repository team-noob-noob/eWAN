using System.Collections.Generic;

namespace eWAN.Core.Domains.Account
{
    public class Guardian : ValueObject
    {
        public string name { get; private set; }
        public PhoneNumber mobileNumber { get; private set; }

        private Guardian()
        {}

        public Guardian(
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
