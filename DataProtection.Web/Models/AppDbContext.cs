using Microsoft.EntityFrameworkCore;

namespace DataProtection.Web.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :  base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Ignore(p => p.EncryptedId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
