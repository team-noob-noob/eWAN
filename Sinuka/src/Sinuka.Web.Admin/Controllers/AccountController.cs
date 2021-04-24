using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sinuka.Web.Admin.Extensions;
using Sinuka.Web.Admin.ViewModels;
using Sinuka.Core.Domains.Entities;
using Sinuka.Web.Accounts.Services;
using Sinuka.Core.Infrastructure.Database;
using Sinuka.Web.Admin.ViewModels.Accounts;
using Sinuka.Web.Accounts.ViewModels.Account;
using Sinuka.Web.Accounts.Interfaces;

namespace Sinuka.Web.Admin.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/[controller]/[method]")]
    public class AccountController : ControllerBase
    {
        private SinukaDbContext _dbContext;
        private ISinukaWebAccountsService _sinukaWebAccountsEndpoints;

        public AccountController(
            SinukaDbContext dbContext
        ) 
        {
            this._dbContext = dbContext;
            this._sinukaWebAccountsEndpoints = new SinukaWebAccountsService();
        }

        [HttpGet]
        public IEnumerable<User> GetAllUsers([FromBody] UserQueryInputModel queryInputModel, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            return this._dbContext.Set<User>().Where(u => u.Email == queryInputModel.Email).Page(pageNumber, pageSize);
        }

        [HttpPost]
        public Response<AccountCreationOutputModel> CreateAccount(NewUserInputModel newUserInput)
        {
            var response = this._sinukaWebAccountsEndpoints.AddUser(newUserInput);
            return new Response<AccountCreationOutputModel>(new AccountCreationOutputModel()
                {
                    IsCreated = response.Succeeded,
                });
        }

        [HttpPut]
        public Response<AccountUpdateOutputModel> UpdateAccount(UpdateUserInputModel updateUserInput)
        {
            var response = this._sinukaWebAccountsEndpoints.UpdateUser(updateUserInput);
            return new Response<AccountUpdateOutputModel>(new AccountUpdateOutputModel()
                {
                    IsUpdated = response.Succeeded,
                });
        }
    }
}
