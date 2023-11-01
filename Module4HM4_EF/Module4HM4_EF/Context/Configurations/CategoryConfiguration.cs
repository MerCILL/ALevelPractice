using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HM4_EF.Models;

namespace Module4HM4_EF.Context.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasMany(x => x.Breeds).WithOne(x => x.Category);
            builder.HasMany(x => x.Pets).WithOne(x => x.Category);
        }
    }
}
