using eWAN.Domains.Room;

namespace eWAN.Application.Boundaries.CreateRoom
{
    public class CreateRoomOutput
    {
        public CreateRoomOutput(IRoom room) => this.newRoom = room;

        public IRoom newRoom { get; set; }
    }
}
