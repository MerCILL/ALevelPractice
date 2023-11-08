using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Module4_HM4_EF2.DbData.Models;

namespace Module4_HM4_EF2.DbData.ModelsConfiguration
{
    public class PetInsuranceConfiguration : IEntityTypeConfiguration<PetInsurance>
    {
        public void Configure(EntityTypeBuilder<PetInsurance> builder)
        {
            builder.HasKey(x => x.Id).HasName("PK_PetInsuranceId");

            builder.Property(x => x.StartInsuranceDate).IsRequired();
            builder.Property(x => x.EndInsuranceDate).IsRequired();
            builder.Property(x => x.PetId).IsRequired();

            builder
                .HasOne(x => x.Pet)
                .WithOne(x => x.PetInsurance)
                .HasForeignKey<Pet>(x => x.PetInsuranceId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Insurance_PetId");

            builder
              .Property(x => x.StartInsuranceDate)
              .HasConversion(new ValueConverter<DateOnly?, DateTime?>(
                  x => x.HasValue ? x.Value.ToDateTime(TimeOnly.MinValue) : null,
                  y => y.HasValue ? DateOnly.FromDateTime(y.Value) : null));

            builder
              .Property(x => x.EndInsuranceDate)
              .HasConversion(new ValueConverter<DateOnly?, DateTime?>(
                  x => x.HasValue ? x.Value.ToDateTime(TimeOnly.MinValue) : null,
                  y => y.HasValue ? DateOnly.FromDateTime(y.Value) : null));
        }
    }
}
