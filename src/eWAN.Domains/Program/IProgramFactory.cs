using System.Collections.Generic;

namespace eWAN.Domains.Program
{
    using Course;

    public interface IProgramFactory
    {
        IProgram NewProgram(
            string Title,
            string Code,
            string Description,
            List<ICourse> Courses
        );
    }
}
