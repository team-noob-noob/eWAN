using eWAN.Core.Domains.Account;

namespace eWAN.Core.Application.Boundaries.Register
{
    public sealed class RegisterInput
    {
        public RegisterInput(
            Name name,
            Contact contact,
            Guardian guardian,
            string username,
            string password
        ) {
            this.name = name;
            this.guardian = guardian;
            this.contact = contact;
            this.username = username;
            this.password = password;
        }

        public string username { get; }
        public string password { get; }
        public Name name { get; }
        public Contact contact { get; }
        public Guardian guardian { get; }
    }
}
