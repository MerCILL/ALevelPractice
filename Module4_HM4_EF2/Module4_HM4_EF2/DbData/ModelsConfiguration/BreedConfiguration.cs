using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4_HM4_EF2.DbData.Models;

namespace Module4_HM4_EF2.DbData.ModelsConfiguration
{
    public class BreedConfiguration : IEntityTypeConfiguration<Breed>
    {
        public void Configure(EntityTypeBuilder<Breed> builder)
        {
            builder.HasKey(x => x.Id).HasName("PK_BreedId");

            builder.Property(x => x.BreedName).IsRequired();
            builder.Property(x => x.CategoryId).IsRequired();

            builder.HasOne(x => x.Category).WithMany(x => x.Breeds).OnDelete(DeleteBehavior.Restrict).HasConstraintName("FK_Breed_CategoryId");

        }
    }
}
