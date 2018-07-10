using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ApiLivraria.Models
{

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<LivrariaContext>
    {
        public LivrariaContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<LivrariaContext>();

            var connection = @"Server=(localdb)\mssqllocaldb;Database=LivrariaDB;Trusted_Connection=True;ConnectRetryCount=0";

            builder.UseSqlServer(connection);

            return new LivrariaContext(builder.Options);
        }
    }
}
