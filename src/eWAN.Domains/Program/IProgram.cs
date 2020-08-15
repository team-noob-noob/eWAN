using System.Collections.Generic;

namespace eWAN.Domains.Program
{
    using Course;
    using EnrolledProgram;

    public interface IProgram : IBaseEntity
    {
        int Id { get; set; }
        string Code { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        List<ICourse> Courses { get; set; }

        // Inverse Property
        List<IEnrolledProgram> EnrolledStudentsInProgram { get; set; }
    }
}
