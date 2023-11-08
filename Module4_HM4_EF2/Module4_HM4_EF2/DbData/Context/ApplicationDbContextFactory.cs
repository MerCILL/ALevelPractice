using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Module4_HM4_EF2.DbData.Context
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        private static string? _connectionString;
        public ApplicationDbContext CreateDbContext()
        {
            return CreateDbContext(null);
        }

        public ApplicationDbContext CreateDbContext(string[] args)
        {
            if (string.IsNullOrEmpty(_connectionString)) LoadConnectionString();

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseSqlServer(_connectionString);
            return new ApplicationDbContext(builder.Options);
        }

        private static void LoadConnectionString()
        {
            var builder = new ConfigurationBuilder();
            builder.AddUserSecrets<ApplicationDbContextFactory>();

            var configuration = builder.Build();
            _connectionString = configuration.GetConnectionString(nameof(ApplicationDbContext));
        }

    }
}
