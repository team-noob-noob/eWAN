namespace eWAN.Infrastructure.Database.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;
    using Domains.EnrolledProgram;
    using Domains.Program;
    using Domains.Student;

    public class EnrolledProgram : Domains.EnrolledProgram.EnrolledProgram, IEnrolledProgram
    {
        protected EnrolledProgram() {}
        public EnrolledProgram(IStudent Student, IProgram Program)
        {
            this.Student = Student;
            this.Program = Program;
        }

        public override int Id { get; set; }
        public string Student_Id { get; set; }
        public int Program_Id { get; set; }
    }
}
