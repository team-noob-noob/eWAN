using eWAN.Domains.User;
using eWAN.Domains.EnrolledProgram;
using eWAN.Domains.EnrolledSubject;
using eWAN.Domains.Section;
using eWAN.Domains.Program;
using System.Collections.Generic;

namespace eWAN.Domains.Student
{
    /// <summary>Represents a Student Profile</summary>
    public interface IStudent : IBaseEntity
    {
        string Id { get; set; }
        IUser User { get; set; }
        ISection? AssignedSection { get; set; }
        List<IEnrolledSubject> EnrolledSubjects { get; set; }
        List<IEnrolledProgram> EnrolledPrograms { get; set; }
        
        /// <summary>Checks whether the student already finished all courses required in a given program</summary>
        bool IsFinishedStudies(IProgram programToCheck);

        
    }
}
