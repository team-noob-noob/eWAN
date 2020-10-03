namespace eWAN.WebApi.UseCases.LogIn
{
    public class LogInReponse
    {
        public LogInReponse(string session)
        {
            Session = session;
        }

        public string Session { get; }
    }
}
