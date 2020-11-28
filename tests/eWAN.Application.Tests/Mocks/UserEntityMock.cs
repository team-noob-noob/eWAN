using eWAN.Infrastructure.Database.Entities;

namespace eWAN.Tests.Mocks
{
    public class UserEntityMock : User, Domains.User.IUser
    {
        public UserEntityMock(
            string Username,
            string Password, 

            string Email, 
            string PhoneNumber, 

            string FirstName,
            string MiddleName,
            string LastName,

            string Address,
            int Id)
        {
            this.Username = Username;
            this.Password = Password;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.FirstName = FirstName;
            this.MiddleName = MiddleName;
            this.LastName = LastName;
            this.Address = Address;
            this.Id = Id;
        }

        public override int Id { get; protected set; }
        public override string Username { get; set; }
        public override string Password { get; set;}
        public override string Email { get; set; }
        public override string PhoneNumber { get; set; }
        public override string FirstName { get; set; }
        public override string MiddleName { get; set; }
        public override string LastName { get; set; }
        public override string Address { get; set; }
    }
}
