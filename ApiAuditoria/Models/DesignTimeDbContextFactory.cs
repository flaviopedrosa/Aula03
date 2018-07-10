using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ApiAuditoria.Models
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AuditoriaContext>
    {
        public AuditoriaContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<AuditoriaContext>();

            var connection = configuration.GetConnectionString("auditoriaConnection");
            builder.UseSqlServer(connection);

            return new AuditoriaContext(builder.Options);
        }
    }
}
