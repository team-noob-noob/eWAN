using eWAN.Domains.Program;
using eWAN.Domains.User;

namespace eWAN.Domains.EnrolledProgram
{
    public abstract class EnrolledProgram : BaseEntity, IEnrolledProgram
    {
        public abstract int Id { get; set; }
        public virtual IUser Student { get; set; }
        public virtual IProgram Program { get; set; }
    }
}
