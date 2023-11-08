using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4_HM4_EF2.DbData.Models;
using System.Reflection.Emit;

namespace Module4_HM4_EF2.DbData.ModelsConfiguration
{
    public class PetFoodConfiguration : IEntityTypeConfiguration<PetFood>
    {
        public void Configure(EntityTypeBuilder<PetFood> builder)
        {
            builder.HasKey(x => new { x.PetId, x.FoodId }).HasName("PK_PetFoodId");      
        }
    }
}
