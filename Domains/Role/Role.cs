using eWAN.Domains.User;

namespace eWAN.Domains.Role
{
    public abstract class Role : BaseEntity, IRole
    {
        public abstract IUser user { get; set; }

        public abstract UserRole role { get; set; }
    }
}
