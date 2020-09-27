namespace eWAN.Infrastructure.Database.Entities
{
    using System.Collections.Generic;
    using Domains.Section;
    using eWAN.Domains.Student;

    public class Section : Domains.Section.Section, ISection
    {
        public Section() {}
        public Section(string Name, List<IStudent> Students)
        {
            this.Name = Name;
            this.Students = Students;
        }

        public override int Id { get; set; }
        public override string Name { get; set; }
    }
}
