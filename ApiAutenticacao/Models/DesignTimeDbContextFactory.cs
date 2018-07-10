using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ApiAutenticacao.Models
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AutenticaoContext>
    {
        public AutenticaoContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<AutenticaoContext>();

            var connection = configuration.GetConnectionString("autenticacaoConnection");
            builder.UseSqlServer(connection);

            return new AutenticaoContext(builder.Options);
        }
    }
}
