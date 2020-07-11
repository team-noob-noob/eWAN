using System.Threading.Tasks;

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
    }
}
