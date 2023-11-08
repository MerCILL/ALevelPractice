using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HM4_EF.Models;

namespace Module4HM4_EF.Context.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasMany(x => x.Pets).WithOne(x => x.Location);
        }
    }
}
