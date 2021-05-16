using eWAN.Core.Domains.Entities.Base;

namespace eWAN.Core.Domains.Entities.StudentApplicationManagement
{
    public class StudentApplication : Entity
    {
        public User StudentApplying { get; set; }
        public User ApprovingStaffer { get; set; }
        public bool IsAccepted { get; set; }
        public string ReasonOnDecision { get; set; }
        public Attachment[] Requirements  { get; set; }
    }
}
