using Refit;
using Microsoft.AspNetCore.Identity;
using Sinuka.Web.Accounts.ViewModels.Account;

namespace Sinuka.Web.Accounts.Endpoints
{
    public interface ISinukaWebAccountsEndpoint
    {
        [Post("/ExternalClient/AddUser")]
        IdentityResult AddUser(NewUserInputModel newUserInput);

        [Put("/ExternalClient/UpdateUser")]
        IdentityResult UpdateUser(UpdateUserInputModel userInputModel);
    }
}
