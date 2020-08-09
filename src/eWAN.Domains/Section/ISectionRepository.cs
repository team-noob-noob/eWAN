using System.Threading.Tasks;

namespace eWAN.Domains.Section
{
    public interface ISectionRepository
    {
        Task Add(ISection section);
    }
}
