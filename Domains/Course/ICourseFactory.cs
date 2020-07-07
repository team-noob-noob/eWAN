using System.Collections.Generic;

namespace eWAN.Domains.Course
{
    public interface ICourseFactory
    {
        ICourse NewCourse(
            string Id, 
            string Title, 
            string Description, 
            List<ICourse> PrerePrerequisitesquest);
    }
}
