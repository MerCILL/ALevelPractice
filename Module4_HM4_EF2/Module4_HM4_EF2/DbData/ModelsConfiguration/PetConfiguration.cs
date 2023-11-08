using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4_HM4_EF2.DbData.Models;

namespace Module4_HM4_EF2.DbData.ModelsConfiguration
{
    public class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {     
            builder.HasKey(x => x.Id).HasName("PK_PetId");

            builder.Property(x => x.PetName).IsRequired();
            builder.Property(x => x.LocationId).IsRequired();
            builder.Property(x => x.BreedId).IsRequired();

            builder
                .HasOne(x => x.Location)
                .WithMany(x => x.Pets)
                .HasForeignKey(x => x.LocationId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Pet_LocationId");

            builder
                .HasOne(x => x.Category)
                .WithMany(x => x.Pets)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Pet_CategoryId");

            builder
                .HasOne(x => x.Breed)
                .WithMany(x => x.Pets)
                .HasForeignKey(x => x.BreedId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Pet_BreedId");

            builder
                .HasMany(x => x.PetFoods)
                .WithOne(x => x.Pet)
                .HasForeignKey(x => x.PetId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_PetFood_PetId");

            builder
                .HasOne(x => x.PetInsurance)
                .WithOne(x => x.Pet)
                .HasForeignKey<PetInsurance>(x => x.PetId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Pet_InsuranceId");


        }
    }
}
