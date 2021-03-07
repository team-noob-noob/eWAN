using System;
using Microsoft.AspNetCore.Identity;

namespace Sinuka.Core.Domains.Entities
{
    public class UserRole : IdentityUserRole<string>, Base.IEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
