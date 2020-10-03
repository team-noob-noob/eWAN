namespace eWAN.Application.Boundaries.LogIn
{
    public class LogInInput
    {
        public LogInInput(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; }
        public string Password { get; }
    }
}
