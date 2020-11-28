using System.Collections.Generic;

namespace eWAN.Domains.Course
{
    using Program;
    using Subject;

    ///<summary>Represents a study or topic</summary>
    public interface ICourse : IBaseEntity
    {
        string Code { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        List<ICourse> Prerequisites { get; set; }

        // Inverse Property
        IProgram AssignedProgram { get; set; }
        List<ISubject> OpenedSubjects { get; set; }
        ICourse Prerequesite { get; set; }
    }
}
