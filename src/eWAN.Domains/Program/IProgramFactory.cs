using System.Collections.Generic;

namespace eWAN.Domains.Program
{
    using Course;

    public interface IProgramFactory
    {
        IProgram NewProgram(
            string title,
            string code,
            string description,
            List<ICourse> courses
        );
    }
}
