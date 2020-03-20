namespace eWAN.Core.Domains.Entities.Identity
{
    using eWAN.Core.Domains.Entities.Base;
    using eWAN.Core.Domains.ValueObjects.Identity;

    public class User : BaseEntity
    {
        public string username { get; protected set; }
        public string password { get; protected set; }
        public UserDetails details { get; protected set; }
        public UserContacts contacts { get; protected set; }
        public UserGuardian guardian { get; protected set; }
    }
}
