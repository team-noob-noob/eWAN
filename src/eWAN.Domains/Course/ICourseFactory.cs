using System.Collections.Generic;
using eWAN.Domains.Program;

namespace eWAN.Domains.Course
{
    public interface ICourseFactory
    {
        ICourse NewCourse(
            string id, 
            string title, 
            string description, 
            List<ICourse> prerequisites,
            IProgram program);
    }
}
