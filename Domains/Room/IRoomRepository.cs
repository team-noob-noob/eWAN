using System.Threading.Tasks;

namespace eWAN.Domains.Room
{
    public interface IRoomRepository
    {
        Task Add(IRoom room);
        Task<IRoom> GetRoomById(string Id);
    }
}
