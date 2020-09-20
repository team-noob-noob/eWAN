using System.Collections.Generic;
using eWAN.Domains.Student;

namespace eWAN.Domains.Section
{
    public interface ISectionFactory
    {
        ISection NewSection(
            string Name,
            List<IStudent> Students
        );
    }
}
