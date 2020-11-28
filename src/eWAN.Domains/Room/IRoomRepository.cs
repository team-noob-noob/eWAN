using System.Threading.Tasks;

namespace eWAN.Domains.Room
{
    public interface IRoomRepository
    {
        Task Add(IRoom room);
        Task<IRoom> GetRoomByCode(string id);
    }
}
