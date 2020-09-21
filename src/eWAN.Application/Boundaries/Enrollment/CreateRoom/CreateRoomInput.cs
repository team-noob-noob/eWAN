namespace eWAN.Application.Boundaries.CreateRoom
{
    public class CreateRoomInput
    {
        public CreateRoomInput(string Id, string Name, string Address)
        {
            this.Id = Id;
            this.Name = Name;
            this.Address = Address;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }    
}
