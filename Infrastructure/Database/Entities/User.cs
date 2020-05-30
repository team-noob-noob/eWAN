using System;

namespace eWAN.Infrastructure.Database.Entities
{
    public sealed class User : Domains.User.User
    {
        public User(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
            this.Id = DateTime.Now.Year.ToString() + RandomUtil.GenerateRandomNumber();
        }

        public override string Id { get; set; }
        public override string Username { get; protected set; }
        public override string Password { get; protected set; }
    }

    internal class RandomUtil
    {
        public static string GenerateRandomNumber()
        {
            string res = "";
            Random rand = new Random();

            for(int i = 0; i < 5; i++)
            {
                res += rand.Next().ToString();
            }

            return res;
        }
    }
}

