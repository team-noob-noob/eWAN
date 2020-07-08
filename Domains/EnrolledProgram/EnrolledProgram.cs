using eWAN.Domains.Program;
using eWAN.Domains.User;

namespace eWAN.Domains.EnrolledProgram
{
    public abstract class EnrolledProgram : BaseEntity, IEnrolledProgram
    {
        public abstract int Id { get; set; }
        public abstract IUser Student { get; set; }
        public abstract IProgram Program { get; set; }
    }
}
