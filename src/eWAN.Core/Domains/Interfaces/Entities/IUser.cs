using eWAN.Core.Domains.ValueObjects.Identity;

namespace eWAN.Core.Domains.Interfaces.Entities
{
    public interface IUser
    {
        string username { get; }
        string password { get; }
        UserDetails details { get; }
        UserContacts contacts { get; }
        UserGuardian guardian { get; }
    }
}
