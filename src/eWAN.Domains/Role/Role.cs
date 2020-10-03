using eWAN.Domains.User;

namespace eWAN.Domains.Role
{
    public abstract class Role : BaseEntity, IRole
    {
        public abstract int Id { get; set; }

        public virtual IUser User { get; set; }

        public virtual UserRole UserRole { get; set; }
    }
}
