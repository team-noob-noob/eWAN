namespace eWAN.Core.Domains.ValueObjects
{
    using eWAN.Core.Domains.ValueObjects.Base;

    public class Address : ValueObject
    {
        public string street { get; private set; }
        public string barangay { get; private set; }
        public string subdivision { get; private set; }
        public string city { get; private set; }
        public string region { get; private set; }
        public string zip { get; private set; }

        private Address()
        {}
        public Address(
            string street,
            string barangay,
            string subdivision,
            string city,
            string region,
            string zip
        )
        {
            this.street = street;
            this.barangay = barangay;
            this.subdivision = subdivision;
            this.city = city;
            this.region = region;
            this.zip = zip;
        }

        public override string ToString()
        {
            return $"{street}, {barangay}, {subdivision}, {city}, {region}, {zip}";
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return street;
            yield return barangay;
            yield return subdivision;
            yield return city;
            yield return region;
            yield return zip;
        }
    }
}