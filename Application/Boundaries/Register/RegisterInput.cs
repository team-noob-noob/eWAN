namespace eWAN.Application.Boundaries.Register
{
    using Domains.User;

    public class RegisterInput : IUser
    {
        public RegisterInput(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}
