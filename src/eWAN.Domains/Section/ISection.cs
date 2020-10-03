using System.Collections.Generic;
using eWAN.Domains.Student;

namespace eWAN.Domains.Section
{
    ///<summary>A group of students that is enrolled on regular schedule</summary>
    public interface ISection
    {
        int Id { get; set; }
        string Name { get; set; }
        List<IStudent> Students { get; set; }
    }
}
