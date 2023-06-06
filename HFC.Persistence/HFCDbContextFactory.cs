using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HFC.Persistence.Repositories
{
    public class HFCDbContextFactory : IDesignTimeDbContextFactory<HFCDbContext>
    {
        public HFCDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();

            var builder = new DbContextOptionsBuilder<HFCDbContext>();
            var connectionString = configuration.GetConnectionString("HFCConnectionString");

            builder.UseNpgsql(connectionString);

            return new HFCDbContext(builder.Options);
        }
    }
}