namespace eWAN.Application.Boundaries.Register
{
    public class RegisterInput
    {
        public RegisterInput(
            string username,
            string password, 

            string email, 
            string phoneNumber, 

            string firstName,
            string middleName,
            string lastName,

            string address)
        {
            Username = username;
            Password = password;

            Email = email;
            PhoneNumber = phoneNumber;
            
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;

            Address = address;
        }

        public string Username { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }
    }
}
