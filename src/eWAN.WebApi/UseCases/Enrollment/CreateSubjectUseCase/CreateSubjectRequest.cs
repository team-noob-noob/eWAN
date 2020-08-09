namespace eWAN.WebApi.UseCases.CreateSubject
{
    using Domains.Session;
    using System.Collections.Generic;

    public class CreateSubjectRequest
    {
        public string RoomId { get; set; }
        public string CourseId { get; set; }
        public List<ISession> Sessions { get; set; }
        public string SemesterCode { get; set; }
        public string InstructorId { get; set; }
    }
}
