using eWAN.Core.Domains.Entities;

namespace eWAN.Application.UseCases.StudentApplicationManagement.PostStudentApplication
{
    public class PostStudentApplcationInput
    {
        public Attachment[] Documents { get; set; }
        public int ApplicantId { get; set; }
    }
}
