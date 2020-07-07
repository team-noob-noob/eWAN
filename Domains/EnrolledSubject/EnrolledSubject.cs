using eWAN.Domains.Subject;
using eWAN.Domains.User;

namespace eWAN.Domains.EnrolledSubject
{
    public abstract class EnrolledSubject : BaseEntity, IEnrolledSubject
    {
        public abstract int Id { get; set; }
        public abstract IUser enrolledStudent { get; set; }
        public abstract ISubject subject { get; set; }
        public abstract string grade { get; set; }
    }
}
