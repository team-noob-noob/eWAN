namespace eWAN.WebApi.UseCases.Register
{
    public sealed class RegisterResponse
    {
        public RegisterResponse(string Id)
        {
            this.Id = Id;
        }

        public string Id { get; }
    }
}
