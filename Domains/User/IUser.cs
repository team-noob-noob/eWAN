namespace eWAN.Domains.User
{
    public interface IUser : IBaseEntity
    {
        string? Id { get; }

        string Username { get; }
        string Password { get; }

        string Email { get; }
        string PhoneNumber { get; }
        
        string FirstName { get; }
        string MiddleName { get; }
        string LastName { get; }

        string Address { get; }
    }
}
