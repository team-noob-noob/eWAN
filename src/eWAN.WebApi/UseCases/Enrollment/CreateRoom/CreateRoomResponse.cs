namespace eWAN.WebApi.UseCases.CreateRoom
{
    public class CreateRoomResponse
    {
        public CreateRoomResponse(string RoomId)
        {
            this.NewRoomId = RoomId;
        }

        public string NewRoomId { get; }   
    }
}
