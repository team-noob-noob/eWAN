namespace eWAN.Domains.Role
{
    using User;

    ///<summary>
    /// Represents allowed accessibility for a given user
    /// </summary>
    public interface IRole : IBaseEntity
    {
        IUser User { get; }
        UserRole UserRole { get; set; }
    }
}
