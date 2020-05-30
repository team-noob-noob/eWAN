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
            this.Id = DateTime.Now.Year.ToString() + RandomUtil.GenerateRandomNumber();
        }

        public override string Id { get; set; }
        public override string Username { get; protected set; }
        public override string Password { get; protected set; }
        public override string Email { get; protected set; }
        public override string PhoneNumber { get; protected set; }
        public override string FirstName { get; protected set; }
        public override string MiddleName { get; protected set; }
        public override string LastName { get; protected set; }
        public override string Address { get; protected set; }
    }

    internal class RandomUtil
    {
        public static string GenerateRandomNumber()
        {
            string res = "";
            Random rand = new Random();

            for(int i = 0; i < 5; i++)
            {
                res += (rand.Next() % 10).ToString();
            }

            return res;
        }
    }
}

