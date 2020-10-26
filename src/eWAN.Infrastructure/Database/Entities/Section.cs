using System.Collections.Generic;
using eWAN.Domains.Section;
using eWAN.Domains.Student;

namespace eWAN.Infrastructure.Database.Entities
{
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
