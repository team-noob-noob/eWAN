namespace eWAN.Domains.Room
{
    public interface IRoomFactory
    {
        IRoom NewRoom(
            string Id,
            string Name,
            string Address
        );
    }
}
