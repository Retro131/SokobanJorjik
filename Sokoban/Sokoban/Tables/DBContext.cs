using Microsoft.EntityFrameworkCore;

namespace Sokoban
{
    internal class DBContext : DbContext
    {
        DbSet<Levels> Levels { get; set; }
        DbSet<Results> Results { get; set; }
        DbSet<Users> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP1;Database=Zoohotel;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
