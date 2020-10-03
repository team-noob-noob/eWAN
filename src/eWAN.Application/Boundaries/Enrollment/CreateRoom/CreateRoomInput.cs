namespace eWAN.Application.Boundaries.CreateRoom
{
    public class CreateRoomInput
    {
        public CreateRoomInput(string id, string name, string address)
        {
            Id = id;
            Name = name;
            Address = address;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }    
}
