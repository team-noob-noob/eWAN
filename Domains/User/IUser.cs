namespace eWAN.Domains.User
{
    public interface IUser : IBaseEntity
    {
        string Id { get; }

        string Username { get; set; }
        string Password { get; set; }

        string Email { get; set; }
        string PhoneNumber { get; set; }
        
        string FirstName { get; set; }
        string MiddleName { get; set; }
        string LastName { get; set; }

        string Address { get; set; }
    }
}
