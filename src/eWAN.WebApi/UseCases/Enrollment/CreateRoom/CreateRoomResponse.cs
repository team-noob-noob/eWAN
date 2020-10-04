namespace eWAN.WebApi.UseCases.CreateRoom
{
    public class CreateRoomResponse
    {
        public CreateRoomResponse(string roomId)
        {
            NewRoomId = roomId;
        }

        public string NewRoomId { get; }   
    }
}
