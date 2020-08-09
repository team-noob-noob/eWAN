namespace eWAN.Domains.Application
{
    using User;

    public interface IApplicationFactory
    {
        IApplication NewApplication(IUser applicant);
    }
}
