using Microsoft.EntityFrameworkCore;
using Module4HM4_EF.Models;

namespace Module4HM4_EF.Context
{
    public class PetContext : DbContext
    {
        public DbSet<Pet> Pets { get; private set; }
        public PetContext(DbContextOptions<PetContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

    }
}
