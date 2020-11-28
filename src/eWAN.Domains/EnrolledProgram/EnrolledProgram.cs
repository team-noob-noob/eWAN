using eWAN.Domains.Program;
using eWAN.Domains.Student;

namespace eWAN.Domains.EnrolledProgram
{
    public abstract class EnrolledProgram : BaseEntity, IEnrolledProgram
    {
        public virtual IStudent Student { get; set; }
        public virtual IProgram Program { get; set; }
    }
}
