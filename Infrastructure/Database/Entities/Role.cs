using eWAN.Domains.Role;
using eWAN.Domains.User;

namespace eWAN.Infrastructure.Database.Entities
{
    public sealed class Role : Domains.Role.Role, IRole
    {
        public Role() {}

        public Role(IUser user, UserRole role)
        {
            this.user = user;
            this.role = role;
        }

        public override int Id { get; set; }

        public override UserRole role { get; set; }

        public string User_Id { get; set; }
    }
}
