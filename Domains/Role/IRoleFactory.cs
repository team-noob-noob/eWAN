namespace eWAN.Domains.Role
{
    using User;

    public interface IRoleFactory
    {
        IRole NewRole(IUser user, UserRole role = UserRole.StudentApplicant);
    }
}
