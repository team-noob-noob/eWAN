using System.Threading.Tasks;

namespace eWAN.Domains.EnrolledProgram
{
    public interface IEnrolledProgramRepository
    {
        Task Add(IEnrolledProgram enrolledProgram);        
    }
}
