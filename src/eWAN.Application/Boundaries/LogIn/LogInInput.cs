namespace eWAN.Application.Boundaries.LogIn
{
    public class LogInInput
    {
        public LogInInput(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }

        public string Username { get; }
        public string Password { get; }
    }
}
