using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HM4_EF.Models;

namespace Module4HM4_EF.Context.Configurations
{
    public class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.HasOne(x => x.Category).WithMany(x => x.Pets);
            builder.HasOne(x => x.Breed).WithMany(x => x.Pets);
            builder.HasOne(x => x.Location).WithMany(x => x.Pets);
        }
    }
}
