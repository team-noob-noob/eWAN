using Refit;
using Microsoft.AspNetCore.Identity;
using Sinuka.Web.Accounts.ViewModels.Account;

namespace Sinuka.Web.Accounts.Endpoints
{
    public interface ISinukaWebAccountsEndpoint
    {
        [Post("/ExternalClient/AddUser")]
        IdentityResult AddUser(NewUserInputModel newUserInput, [Authorize("Bearer")] string token);

        [Put("/ExternalClient/UpdateUser")]
        IdentityResult UpdateUser(UpdateUserInputModel userInputModel, [Authorize("Bearer")] string token);
    }
}
