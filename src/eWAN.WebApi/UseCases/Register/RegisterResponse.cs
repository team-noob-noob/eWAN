namespace eWAN.WebApi.UseCases.Register
{
    public sealed class RegisterResponse
    {
        public RegisterResponse(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
