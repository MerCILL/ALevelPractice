using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4_HM4_EF2.DbData.Models;

namespace Module4_HM4_EF2.DbData.ModelsConfiguration
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(x => x.Id).HasName("PK_LocationId");

            builder.HasIndex(x => x.LocationName).IsUnique().HasDatabaseName("IX_LocationName");

            builder.Property(x => x.LocationName).IsRequired();        
        }
    }
}
