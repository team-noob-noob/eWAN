using System.Threading.Tasks;
using System.Linq;

namespace eWAN.Infrastructure.Database.Repositories
{
    using Domains.Room;
    using Room = Entities.Room;

    public class RoomRepository : IRoomRepository
    {
        public RoomRepository(EwanContext context) => this._context = context;
        private EwanContext _context;

        public async Task Add(IRoom room)
        {
            this._context.Rooms.Add((Room) room);
            await this._context.SaveChangesAsync();
        }

        public async Task<IRoom> GetRoomById(string Id)
        {
            var room = this._context.Rooms.FirstOrDefault(x => x.Id == Id && x.deletedAt == null);
            if(room is null)
            {
                return null;
            }
            return await Task.FromResult(room);
        }
    }
}
