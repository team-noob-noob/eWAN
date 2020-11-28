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

        public override string Name { get; set; }
    }
}
