namespace eWAN.Domains.Room
{
    public interface IRoom : IBaseEntity
    {
        string Id { get; }
        string Name { get; set; }
        string Address { get; set; }
    }
}
