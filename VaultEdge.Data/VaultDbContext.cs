using Microsoft.EntityFrameworkCore;
using VaultEdge.Core.Models;

namespace VaultEdge.Data
{
    public class VaultDbContext : DbContext
    {
        public VaultDbContext(DbContextOptions<VaultDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<VaultItem> VaultItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();

            modelBuilder.Entity<VaultItem>().HasKey(v => v.Id);
            modelBuilder.Entity<VaultItem>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(v => v.UserId);
        }
    }
}
