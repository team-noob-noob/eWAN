using System.Collections.Generic;

namespace eWAN.Domains.Program
{
    using Course;
    using EnrolledProgram;

    ///<summary>
    /// Represents a curriculum that is required to be accomplished
    /// </summary>
    public interface IProgram : IBaseEntity
    {
        string Code { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        List<ICourse> Courses { get; set; }

        // Inverse Property
        List<IEnrolledProgram> EnrolledStudentsInProgram { get; set; }
    }
}
