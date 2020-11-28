using eWAN.Domains.Role;
using eWAN.Domains.User;

namespace eWAN.Infrastructure.Database.Entities
{
    public class Role : Domains.Role.Role, IRole
    {
        public Role() {}

        public Role(IUser user, UserRole role)
        {
            this.User = user;
            this.UserRole = role;
        }

        public override UserRole UserRole { get; set; }

        public int User_Id { get; set; }
    }
}
