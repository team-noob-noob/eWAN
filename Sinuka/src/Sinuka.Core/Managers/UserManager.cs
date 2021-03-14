using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Sinuka.Core.Domains.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Sinuka.Core.Managers
{
    public class UserManager : UserManager<User>
    {
        public UserManager(
            IUserStore<User> userStore,
            IOptions<IdentityOptions> options,
            IPasswordHasher<User> hasher,
            IEnumerable<IUserValidator<User>> userValidators,
            IEnumerable<IPasswordValidator<User>> passwordValidators,
            ILookupNormalizer normalizer,
            IdentityErrorDescriber errorDescriber,
            IServiceProvider services,
            ILogger<UserManager<User>> logger) :
            base(
                userStore,
                options,
                hasher,
                userValidators,
                passwordValidators,
                normalizer,
                errorDescriber,
                services,
                logger
            )
        { }

        public User? FindByUsername(string username) => this.Users.FirstOrDefault(u => u.UserName == username);

        public async Task<bool> ValidateCredentials(string username, string password) 
        {
            var user = FindByUsername(username);
            if(user is null) return false;
            
            return await this.CheckPasswordAsync(user, password);
        }
    }
}
