using System;

namespace eWAN.Infrastructure.Database.Entities
{
    using Domains.User;

    public sealed class User : Domains.User.User, IUser
    {
        public User(
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
            this.Id = DateTime.Now.Year.ToString() + new Random().NewString(10, "0123456789");
        }

        public override string Id { get; protected set; }
        public override string Username { get; set; }
        public override string Password { get; set; }
        public override string Email { get; set; }
        public override string PhoneNumber { get; set; }
        public override string FirstName { get; set; }
        public override string MiddleName { get; set; }
        public override string LastName { get; set; }
        public override string Address { get; set; }
    }
}

