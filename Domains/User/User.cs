namespace eWAN.Domains.User
{
    public abstract class User : BaseEntity, IUser
    {
        public abstract string Username { get; set; }
        public abstract string Password { get; set; }


        public abstract string Id { get; protected set; }

        public abstract string Email { get; set; }

        public abstract string PhoneNumber { get; set; }

        public abstract string FirstName { get; set; }

        public abstract string MiddleName { get; set; }

        public abstract string LastName { get; set; }

        public abstract string Address { get; set; }
    }
}
