using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Coursework.API
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDBContext>
    {
        public ApplicationDBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var databaseDirectory = Path.GetDirectoryName(Directory.GetCurrentDirectory()) + "\\Database";
            connectionString = connectionString.Replace("|DataDirectory|", databaseDirectory);
            if (!Directory.Exists(databaseDirectory))
                Directory.CreateDirectory(databaseDirectory);

            var builder = new DbContextOptionsBuilder<ApplicationDBContext>();
            builder.UseSqlServer(connectionString);

            return new ApplicationDBContext(builder.Options);
        }
    }
}
