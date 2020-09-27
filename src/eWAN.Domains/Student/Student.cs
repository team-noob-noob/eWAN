using System.Collections.Generic;
using eWAN.Domains.EnrolledProgram;
using eWAN.Domains.EnrolledSubject;
using eWAN.Domains.Program;
using eWAN.Domains.Section;
using eWAN.Domains.User;
using System.Linq;

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
            bool isAnyCourseNotFinished = false;

            foreach(var course in programToCheck.Courses)
            {
                // Get the Subjects in a Course that the student was enrolled in
                var subjects = EnrolledSubjects.Where(x => x.subject.Course.Id == course.Id);
            
                // If any of those subjects weren't graded, the course is not complete
                if(subjects.Any(x => string.IsNullOrEmpty(x.grade)))
                {
                    isAnyCourseNotFinished = true;
                    break;
                }
            }
            
            return !isAnyCourseNotFinished;
        }
    }
}
