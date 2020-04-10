using System.Collections.Generic;

namespace eWAN.Core.Domains.Account
{
    public class PhoneNumber : ValueObject
    {
        public string countryCode { get; private set; }
        public string areaCode { get; private set; }
        public string extension { get; private set; }

        private PhoneNumber()
        {}

        public PhoneNumber(string phoneNumber)
        {
            // +63                  xxx             xxxxxx
            // Country Code         Area Code       Extension
            // If the start contains a valid country code
            // TODO: Add proper checking of country code
            if(phoneNumber.StartsWith("+63"))
            {
                countryCode = "+63";
                areaCode = phoneNumber.Substring(3, 3);
                extension = phoneNumber.Substring(6);
            }

            // If the start is 09xx xxxxxxx
            if(phoneNumber.StartsWith("09") && phoneNumber.Length == 11)
            {
                countryCode = "+63";
                areaCode = phoneNumber.Substring(1, 3);
                extension = phoneNumber.Substring(4);
            }
        }

        public PhoneNumber(
            string countryCode,
            string areaCode,
            string extension
        )
        {
            this.countryCode = countryCode;
            this.areaCode = areaCode;
            this.extension = extension;
        }

        public override string ToString()
        {
            return countryCode + areaCode + extension;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return countryCode;
            yield return areaCode;
            yield return extension;
        }
    }
}
