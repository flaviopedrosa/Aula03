using Microsoft.EntityFrameworkCore;


namespace ApiAutenticacao.Models
{
    public class AutenticaoContext : DbContext
    {

        public AutenticaoContext(DbContextOptions<AutenticaoContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
              modelBuilder.Entity<User>()
                .HasKey(x => x.UserID);
        }

        public DbSet<User> Users { get; set; }
    }
}
