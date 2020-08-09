namespace eWAN.Domains.Application
{
    using User;

    public interface IApplication : IBaseEntity
    {
        string Id { get; }
        IUser applicant { get; set; }
        IUser staff { get; set; }
        bool isAccepted { get; set; }
        string reason { get; set; }
    }
}
