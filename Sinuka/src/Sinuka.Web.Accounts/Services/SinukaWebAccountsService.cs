using Refit;
using Microsoft.AspNetCore.Identity;
using Sinuka.Web.Accounts.Endpoints;
using Sinuka.Web.Accounts.Interfaces;
using Sinuka.Core.Infrastructure.Configs;
using Sinuka.Web.Accounts.ViewModels.Account;

namespace Sinuka.Web.Accounts.Services
{
    public class SinukaWebAccountsService : ISinukaWebAccountsService
    {
        private readonly ISinukaWebAccountsEndpoint _sinukaWebAccountsEndpoint;

        public SinukaWebAccountsService(string baseUrl = null)
        {
            this._sinukaWebAccountsEndpoint = RestService.For<ISinukaWebAccountsEndpoint>(baseUrl ?? HostConfig.AccountsSyncUrl);
        }

        public IdentityResult AddUser(NewUserInputModel newUserInput)
        {
            return this._sinukaWebAccountsEndpoint.AddUser(newUserInput);
        }

        public IdentityResult UpdateUser(UpdateUserInputModel userInputModel)
        {
            return this._sinukaWebAccountsEndpoint.UpdateUser(userInputModel);
        }
    }
}
