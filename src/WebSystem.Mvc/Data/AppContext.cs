using Microsoft.EntityFrameworkCore;
using WebSystem.Mvc.Models;

namespace WebSystem.Mvc.Data
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = true;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
