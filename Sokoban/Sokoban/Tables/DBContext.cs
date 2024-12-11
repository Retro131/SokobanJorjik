using Microsoft.EntityFrameworkCore;

namespace Sokoban
{
    public class DBContext : DbContext
    {
        public DbSet<Levels> Levels { get; set; }
        public DbSet<Results> Results { get; set; }
        public DbSet<Users> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP1;Database=Sokoban;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
