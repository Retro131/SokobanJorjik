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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Results>()
                .HasOne(r => r.Users)
                .WithMany(u => u.Results)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Results>()
                .HasOne(r => r.Levels)
                .WithMany(l => l.Results)
                .HasForeignKey(r => r.LevelId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
