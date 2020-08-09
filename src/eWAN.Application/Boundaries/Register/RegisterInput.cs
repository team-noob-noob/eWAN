namespace eWAN.Application.Boundaries.Register
{
    using System;
    using Domains.User;

    public class RegisterInput
    {
        public RegisterInput(
            string Username,
            string Password, 

            string Email, 
            string PhoneNumber, 

            string FirstName,
            string MiddleName,
            string LastName,

            string Address)
        {
            this.Username = Username;
            this.Password = Password;

            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            
            this.FirstName = FirstName;
            this.MiddleName = MiddleName;
            this.LastName = LastName;

            this.Address = Address;
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
