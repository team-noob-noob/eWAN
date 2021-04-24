using Microsoft.AspNetCore.Identity;
using Sinuka.Web.Accounts.ViewModels.Account;

namespace Sinuka.Web.Accounts.Interfaces
{
    public interface ISinukaWebAccountsService
    {
        IdentityResult AddUser(NewUserInputModel newUserInput);

        IdentityResult UpdateUser(UpdateUserInputModel userInputModel);
    }
}
