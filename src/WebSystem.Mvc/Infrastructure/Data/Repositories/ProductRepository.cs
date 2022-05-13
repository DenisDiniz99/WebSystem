using Microsoft.EntityFrameworkCore;
using WebSystem.Mvc.Core.Interfaces;
using WebSystem.Mvc.Core.Models;

namespace WebSystem.Mvc.Infrastructure.Data.Repositories
{
    public class ProductRepository : BaseRepositoy<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext appContext) : base(appContext) { }

        public override async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _dbSet.OrderBy(p => p.Name)
                            .Include(s => s.Supplier)
                            .Include(c => c.Category)
                            .ToListAsync();
        }

        public override async Task<Product> GetByIdAsync(Guid id)
        {
            return await _dbSet.Include(s => s.Supplier)
                                .Include(c => c.Category)
                                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
