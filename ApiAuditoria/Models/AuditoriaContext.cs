using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAuditoria.Models
{
    public class AuditoriaContext : DbContext
    {
        public AuditoriaContext(DbContextOptions<AuditoriaContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Log>()
              .HasKey(x => x.Id);
        }

        public DbSet<Log> Logs { get; set; }
    }
}
