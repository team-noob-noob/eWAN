using eWAN.Domains.Room;

namespace eWAN.Application.Boundaries.CreateRoom
{
    public class CreateRoomOutput
    {
        public CreateRoomOutput(IRoom room) => NewRoom = room;

        public IRoom NewRoom { get; set; }
    }
}
