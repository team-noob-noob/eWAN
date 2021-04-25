using Refit;
using Microsoft.AspNetCore.Identity;
using Sinuka.Web.Accounts.Endpoints;
using Sinuka.Web.Accounts.Interfaces;
using Sinuka.Core.Infrastructure.Configs;
using Sinuka.Web.Accounts.ViewModels.Account;
using Sinuka.Web.Services;
using Sinuka.Web.Interfaces;
using Sinuka.Web.ValueObjects;

namespace Sinuka.Web.Accounts.Services
{
    public class SinukaWebAccountsService : ISinukaWebAccountsService
    {
        private readonly ISinukaWebAccountsEndpoint _sinukaWebAccountsEndpoint;
        private readonly ISinukaWebService _sinukaWebService;

        public SinukaWebAccountsService(string accountsBaseUrl = null, string identityBaseUrl = null)
        {
            this._sinukaWebAccountsEndpoint = RestService.For<ISinukaWebAccountsEndpoint>(accountsBaseUrl ?? HostConfig.AccountsSyncUrl);
            this._sinukaWebService = new SinukaWebService(identityBaseUrl);
        }

        private string LoginAndFetchToken()
        {
            var token = this._sinukaWebService.Authenticate(new ClientCredentialsTokenRequest() {
                GrantType = "client_credentials",
                Scope = "ClientToIdentity",
                ClientId = "sinukaWebAccounts",
                ClientSecret = "511536EF-F270-4058-80CA-1C89C192F69A"
            });

            return token.AccessToken;
        }

        public IdentityResult AddUser(NewUserInputModel newUserInput)
        {
            return this._sinukaWebAccountsEndpoint.AddUser(newUserInput, LoginAndFetchToken());
        }

        public IdentityResult UpdateUser(UpdateUserInputModel userInputModel)
        {
            return this._sinukaWebAccountsEndpoint.UpdateUser(userInputModel, LoginAndFetchToken());
        }
    }
}
