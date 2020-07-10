namespace eWAN.Infrastructure.Database.Entities
{
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
        public override IUser Student { get; set; }
        public override IProgram Program { get; set; }
    }
}
