using System.Collections.Generic;

namespace eWAN.Infrastructure.Database.Entities
{
    using Domains.Course;

    public sealed class Course : Domains.Course.Course, ICourse
    {
        public Course() {}
        public Course(string Id, string Title, string Description, IEnumerable<ICourse> Prerequisites)
        {
            this.Id = Id;
            this.Title = Title;
            this.Description = Description;
            this.Prerequisites = Prerequisites ?? new HashSet<ICourse>();
        }

        public override string Id { get; set; }
        public override string Title { get; set; }
        public override string Description { get; set; }
        public override IEnumerable<ICourse> Prerequisites { get; set; }
    }
}
