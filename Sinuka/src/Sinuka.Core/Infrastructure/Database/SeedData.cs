using Microsoft.EntityFrameworkCore;
using Sinuka.Core.Domains.Entities;
using Sinuka.Core.Domains.Constants;

namespace Sinuka.Core.Infrastructure.Database
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role(UserRoleTypes.Administrator),
                new Role(UserRoleTypes.SuperUser),
                new Role(UserRoleTypes.Student),
                new Role(UserRoleTypes.StudentApplicant)
            );
        }
    }
}
