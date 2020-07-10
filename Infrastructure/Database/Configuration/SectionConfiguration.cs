using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace eWAN.Infrastructure.Database.Configuration
{
    using Entities;
    using Section = Entities.Section;
    
    public sealed class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.HasMany<User>(x => (IEnumerable<User>) x.Students);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.ToTable("Sections");
        }
    }
}
