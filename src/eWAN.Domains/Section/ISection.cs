using System.Collections.Generic;
using eWAN.Domains.Student;

namespace eWAN.Domains.Section
{
    public interface ISection
    {
        int Id { get; set; }
        string Name { get; set; }
        List<IStudent> Students { get; set; }
    }
}
