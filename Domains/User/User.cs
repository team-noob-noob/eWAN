namespace eWAN.Domains.User
{
    public abstract class User : BaseEntity, IUser
    {
        public abstract string Username { get; protected set; }
        public abstract string Password { get; protected set; }


        public abstract string Id { get; set; }

        public abstract string Email { get; protected set; }

        public abstract string PhoneNumber { get; protected set; }

        public abstract string FirstName { get; protected set; }

        public abstract string MiddleName { get; protected set; }

        public abstract string LastName { get; protected set; }

        public abstract string Address { get; protected set; }
    }
}
