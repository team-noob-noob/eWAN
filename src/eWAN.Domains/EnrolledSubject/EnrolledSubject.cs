using eWAN.Domains.Subject;
using eWAN.Domains.User;
using eWAN.Domains.Student;

namespace eWAN.Domains.EnrolledSubject
{
    public abstract class EnrolledSubject : BaseEntity, IEnrolledSubject
    {
        public abstract int Id { get; set; }
        public virtual IStudent enrolledStudent { get; set; }
        public virtual ISubject subject { get; set; }
        public abstract string grade { get; set; }
    }
}
