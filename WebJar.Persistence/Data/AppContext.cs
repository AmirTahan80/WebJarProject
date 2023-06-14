using Microsoft.EntityFrameworkCore;
using WebJar.Domain.Entities;

namespace WebJar.Persistence.Data
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options):base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyValue> PropertyValues { get; set; }
        public DbSet<AddOn> AddOns { get; set; }
        public DbSet<Discount> Discounts { get; set; }
    }
}
