namespace eWAN.Domains.Room
{
    public interface IRoomFactory
    {
        IRoom NewRoom(
            string id,
            string name,
            string address
        );
    }
}
