using System.Collections.Generic;

namespace eWAN.Infrastructure.Database.Entities
{
    using Domains.Course;

    public sealed class Course : Domains.Course.Course, ICourse
    {
        public override string Id { get; set; }
        public override string Title { get; set; }
        public override string Description { get; set; }
        public override IEnumerable<ICourse> Prerequisites { get; set; } = new HashSet<ICourse>();
    }
}
