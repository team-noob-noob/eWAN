using System.Collections.Generic;

namespace eWAN.Core.Domains.Account
{
    public class Contact : ValueObject
    {
        public string emailAddress { get; private set; }
        public PhoneNumber mobileNumber { get; private set; }
        public Address homeAddress { get; private set; }

        private Contact()
        {}
        
        public Contact(
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
}
