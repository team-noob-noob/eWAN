using System.Threading.Tasks;

namespace eWAN.Core.Domains.Account
{
    public interface IAccountFactory
    {
        Task NewAccount(
            Address address,
            Contact contact,
            Guardian guardian,
            Name name
        );
    }
}
