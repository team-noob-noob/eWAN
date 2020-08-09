namespace eWAN.Domains.User
{
    public interface IUserFactory
    {
        IUser NewUser(
            string Username,
            string Password, 

            string Email, 
            string PhoneNumber, 

            string FirstName,
            string MiddleName,
            string LastName,

            string Address);
    }
}
