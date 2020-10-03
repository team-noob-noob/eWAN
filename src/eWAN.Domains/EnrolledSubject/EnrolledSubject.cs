using eWAN.Domains.Subject;
using eWAN.Domains.Student;

namespace eWAN.Domains.EnrolledSubject
{
    public abstract class EnrolledSubject : BaseEntity, IEnrolledSubject
    {
        public abstract int Id { get; set; }
        public virtual IStudent EnrolledStudent { get; set; }
        public virtual ISubject Subject { get; set; }
        public abstract string Grade { get; set; }
    }
}
