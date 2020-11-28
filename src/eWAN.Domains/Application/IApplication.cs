namespace eWAN.Domains.Application
{
    using User;

    ///<summary>
    /// Represents an applicant's application for school enrollment
    /// </summary>
    public interface IApplication : IBaseEntity
    {
        string PublicId { get; }
        IUser Applicant { get; set; }
        IUser Staff { get; set; }
        bool IsAccepted { get; set; }
        string Reason { get; set; }
    }
}
