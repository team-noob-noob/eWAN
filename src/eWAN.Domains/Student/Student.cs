using System.Collections.Generic;
using eWAN.Domains.EnrolledProgram;
using eWAN.Domains.EnrolledSubject;
using eWAN.Domains.Program;
using eWAN.Domains.Section;
using eWAN.Domains.User;

namespace eWAN.Domains.Student
{
    public abstract class Student : BaseEntity, IStudent
    {
        public abstract string Id { get; set; }
        
        public virtual IUser User { get; set; }
        public virtual ISection? AssignedSection { get; set; }
        public virtual List<IEnrolledSubject> EnrolledSubjects { get; set; } = new List<IEnrolledSubject>();
        public virtual List<IEnrolledProgram> EnrolledPrograms { get; set; } = new List<IEnrolledProgram>();

        public bool IsFinishedStudies(IProgram programToCheck)
        {
            throw new System.NotImplementedException();
        }
    }
}
