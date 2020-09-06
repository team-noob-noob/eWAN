using System.Collections.Generic;
using eWAN.Domains.Program;

namespace eWAN.Domains.Course
{
    public interface ICourseFactory
    {
        ICourse NewCourse(
            string Id, 
            string Title, 
            string Description, 
            List<ICourse> Prerequisites,
            IProgram program);
    }
}
