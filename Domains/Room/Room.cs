namespace eWAN.Domains.Room
{
    public abstract class Room : BaseEntity, IRoom
    {
        public abstract string Id { get; set; }
        public abstract string Name { get; set; }
        public abstract string Address { get; set; }
    }
}
