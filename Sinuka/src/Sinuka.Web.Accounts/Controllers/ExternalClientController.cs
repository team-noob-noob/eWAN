using System.Threading.Tasks;
using Sinuka.Web.Accounts.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace Sinuka.Web.Accounts.Controllers.Account
{
    [Authorize("MachineToMachinePolicy")]
    public class ExternalClientController : Controller
    {
        private readonly Sinuka.Core.Managers.UserManager _userManager;

        public ExternalClientController(
            Sinuka.Core.Managers.UserManager userManager)
        {
            this._userManager = userManager;
        }

        [HttpPost]
        public async Task<IdentityResult> AddUser([FromBody] NewUserInputModel newUserInput)
        {
            return await this._userManager.CreateAsync(new Sinuka.Core.Domains.Entities.User() {
                UserName = newUserInput.Username,
                PasswordHash = newUserInput.Password,
                PhoneNumber = newUserInput.PhoneNumber,
                Email = newUserInput.Email,
            }, newUserInput.Password);
        }

        [HttpPut]
        public async Task<IdentityResult> UpdateUser([FromBody] UpdateUserInputModel userInputModel)
        {
            var user = await this._userManager.FindByIdAsync(userInputModel.Id);
            if(user is null) return null;

            user.UserName ??= userInputModel.Username;

            user.Email ??= userInputModel.Email;
            user.EmailConfirmed = !(userInputModel.Email is null) ? false : user.EmailConfirmed;

            user.PhoneNumber ??= userInputModel.PhoneNumber;
            user.PhoneNumberConfirmed = !(userInputModel.PhoneNumber is null) ? false : user.PhoneNumberConfirmed;

            if(userInputModel.IsDeleted) user.DeletedAt = System.DateTime.UtcNow;
            else user.DeletedAt = null;

            if(!(userInputModel.Password is null))
            {
                var resetToken = await this._userManager.GeneratePasswordResetTokenAsync(user);
                await this._userManager.ResetPasswordAsync(user, resetToken, userInputModel.Password);
            }

            return await this._userManager.UpdateAsync(user);
        }
    }
}
