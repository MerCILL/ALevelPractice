using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4_HM4_EF2.DbData.Models;

namespace Module4_HM4_EF2.DbData.ModelsConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id).HasName("PK_CategoryId");

            builder.Property(x => x.CategoryName).IsRequired();


        }
    }
}
