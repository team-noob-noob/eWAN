namespace eWAN.Domains.Room
{
    using Session;

    ///<summary>
    /// Represents a location where students and instructors meet
    /// </summary>
    public interface IRoom : IBaseEntity
    {
        string Code { get; }
        string Name { get; set; }
        string Address { get; set; }

        // Inverse Property
        Schedule Schedule { get; set; }
    }
}
