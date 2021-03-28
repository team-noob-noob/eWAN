namespace Sinuka.Web.Accounts.ViewModels.Account
{
    public class UpdateUserInputModel
    {
        public string Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
