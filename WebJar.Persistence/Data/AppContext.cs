using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebJar.Domain.Entities;

namespace WebJar.Persistence.Data
{
    public class AppContext : DbContext
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyValue> PropertyValues { get; set; }
        public DbSet<AddOn> AddOns { get; set; }
        public DbSet<Discount> Discounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=DESKTOP-1KVE1GP\\SQLEXPRESS;Database=WebJarProject;Trusted_Connection=True;Encrypt=False");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Product>()
                .Property(p => p.ImagesPath)
                .HasConversion(
                    p => string.Join(',', p),
                    p => p.Split(",", StringSplitOptions.RemoveEmptyEntries));

            base.OnModelCreating(builder);
        }
    }
}
