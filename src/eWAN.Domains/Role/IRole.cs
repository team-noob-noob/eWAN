namespace eWAN.Domains.Role
{
    using User;

    public interface IRole : IBaseEntity
    {
        IUser user { get; }
        UserRole role { get; set; }
    }
}
