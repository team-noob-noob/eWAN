namespace eWAN.Core.Domains.ValueObjects
{
    using eWAN.Core.Domains.ValueObjects.Base;

    public class Address : ValueObject
    {
        public string street { get; set; }
        public string barangay { get; set; }
        public string subdivision { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public string zip { get; set; }

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