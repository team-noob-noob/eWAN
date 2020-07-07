using System.Collections.Generic;

namespace eWAN.Domains.Program
{
    using Course;

    public interface IProgram : IBaseEntity
    {
        int Id { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        IEnumerable<ICourse> Courses { get; set; }
    }
}
