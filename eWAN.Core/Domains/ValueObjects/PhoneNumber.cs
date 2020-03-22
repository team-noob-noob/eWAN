namespace eWAN.Core.Domains.ValueObjects
{
    using System.Collections.Generic;
    using eWAN.Core.Domains.ValueObjects.Base;

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
                areaCode = phoneNumber.Substring(2, 3);
                extension = phoneNumber.Substring(6);
            }

            // If the start is 09xx xxxxxxx
            if(phoneNumber.StartsWith("09"))
            {
                countryCode = "";
                areaCode = phoneNumber.Substring(0, 4);
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

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return countryCode;
            yield return areaCode;
            yield return extension;
        }
    }
}