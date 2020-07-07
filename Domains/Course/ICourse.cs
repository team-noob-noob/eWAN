using System.Collections.Generic;

namespace eWAN.Domains.Course
{
    public interface ICourse : IBaseEntity
    {
        string Id { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        IEnumerable<ICourse> Prerequisites { get; set; }
    }
}
