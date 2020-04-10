using eWAN.Core.Domains.ValueObjects.Identity;

namespace eWAN.Core.Domains.Interfaces.Entities
{
    public interface IAccount
    {
        UserDetails details { get; }
        UserContacts contacts { get; }
        UserGuardian guardian { get; }
    }
}
