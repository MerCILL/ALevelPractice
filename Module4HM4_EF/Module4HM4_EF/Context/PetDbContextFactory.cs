using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Module4HM4_EF.Context
{
    public class PetDbContextFactory : IDesignTimeDbContextFactory<PetContext>
    {
        private static string _connectionString;
        public PetContext CreateDbContext()
        {
            return CreateDbContext(null);
        }

        public PetContext CreateDbContext(string[] args)
        {
            if(string.IsNullOrEmpty(_connectionString)) LoadConnectionString();

            var builder = new DbContextOptionsBuilder<PetContext>();
            builder.UseSqlServer(_connectionString);
            return new PetContext(builder.Options);
        }

        private static void LoadConnectionString()
        {
            var builder = new ConfigurationBuilder();
            builder.AddUserSecrets<PetDbContextFactory>();

            var configuration = builder.Build();
             _connectionString = configuration.GetConnectionString(nameof(PetContext));
        }

    }
}
