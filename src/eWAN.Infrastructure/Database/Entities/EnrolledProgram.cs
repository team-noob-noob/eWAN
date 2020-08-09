namespace eWAN.Infrastructure.Database.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;
    using Domains.EnrolledProgram;
    using Domains.Program;
    using Domains.User;

    public sealed class EnrolledProgram : Domains.EnrolledProgram.EnrolledProgram, IEnrolledProgram
    {
        public EnrolledProgram() {}
        public EnrolledProgram(IUser Student, IProgram Program)
        {
            this.Student = Student;
            this.Program = Program;
        }

        public override int Id { get; set; }
        public string Student_Id { get; set; }
        public int Program_Id { get; set; }
    }
}
