using eWAN.Domains.Role;
using eWAN.Domains.User;

namespace eWAN.Infrastructure.Database.Entities
{
    public sealed class Role : Domains.Role.Role, IRole
    {
        public Role() {}

        public Role(IUser userId, UserRole role)
        {
            this.user = user;
            this.role = role;
        }

        public override int Id { get; set; }

        public override IUser user { get; set; }

        public override UserRole role { get; set; }
    }
}
