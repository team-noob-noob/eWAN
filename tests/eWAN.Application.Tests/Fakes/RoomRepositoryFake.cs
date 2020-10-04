using System.Threading.Tasks;
using eWAN.Domains.Room;
using System.Linq;
using Room = eWAN.Infrastructure.Database.Entities.Room;

namespace eWAN.Tests.Fakes
{
    public class RoomRepositoryFake : IRoomRepository
    {
        public RoomRepositoryFake(EwanContextFake context) => _context = context;
        private readonly EwanContextFake _context;

        public async Task Add(IRoom room)
            => await Task.Run(() => _context.Rooms.Add((Room) room));

        public async Task<IRoom> GetRoomById(string id)
            => await Task.Run(() => _context.Rooms.FirstOrDefault(x => x.Id == id));
    }
}
