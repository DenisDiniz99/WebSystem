using Microsoft.EntityFrameworkCore;
using WebSystem.Mvc.Core.Models;

namespace WebSystem.Mvc.Infrastructure.Data
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
