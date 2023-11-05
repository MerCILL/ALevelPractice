using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4_HM4_EF2.DbData.Models;

namespace Module4_HM4_EF2.DbData.ModelsConfiguration
{
    public class FoodConfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.HasKey(x => x.Id).HasName("PK_FoodId");

            builder.Property(x => x.FoodName).IsRequired();
            builder.Property(x => x.FoodType).IsRequired();

            builder.Property(x => x.FoodType).HasConversion<string>();

            builder.HasMany(x => x.PetFoods)
                .WithOne(x => x.Food)
                .HasForeignKey(x => x.FoodId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_PetFood_FoodId");
        }
    }
}
