using eWAN.Core.Domains;

namespace eWAN.Core.Domains.Account
{
    public class Account : BaseEntity
    {
        public UserDetails details { get; protected set; }
        public UserContacts contacts { get; protected set; }
        public UserGuardian guardian { get; protected set; }
    }
}
