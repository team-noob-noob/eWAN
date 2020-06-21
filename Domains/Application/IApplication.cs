namespace eWAN.Domains.Application
{
    using User;

    public interface IApplication : IBaseEntity
    {
        string Id { get; }
        IUser applicant { get; }
        IUser staff { get; }
        bool isAccepted { get; }
        string reason { get; }
    }
}
