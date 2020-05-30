namespace eWAN.Domains.User
{
    public abstract class User : BaseEntity, IUser
    {
        public abstract string Username { get; protected set; }
        public abstract string Password { get; protected set; }
        public abstract string Id { get; set; }
    }
}
