namespace eWAN.Domains.Role
{
    using User;

    public interface IRole
    {
        IUser user { get; }
        UserRole role { get; }
    }
}
