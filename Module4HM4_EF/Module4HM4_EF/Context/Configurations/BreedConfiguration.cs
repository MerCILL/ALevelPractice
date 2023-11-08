using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HM4_EF.Models;

namespace Module4HM4_EF.Context.Configurations
{
    public class BreedConfiguration : IEntityTypeConfiguration<Breed>
    {
        public void Configure(EntityTypeBuilder<Breed> builder)
        {
            builder.HasOne(x => x.Category).WithMany(x => x.Breeds);
            builder.HasMany(x => x.Pets).WithOne(x => x.Breed);
        }
    }
}
