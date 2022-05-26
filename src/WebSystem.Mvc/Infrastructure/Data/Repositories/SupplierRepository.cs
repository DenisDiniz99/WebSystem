using Microsoft.EntityFrameworkCore;
using WebSystem.Mvc.Core.Interfaces;
using WebSystem.Mvc.Core.Models;

namespace WebSystem.Mvc.Infrastructure.Data.Repositories
{
    public class SupplierRepository : BaseRepositoy<Supplier>, ISupplierRepository
    {
        public SupplierRepository(AppDbContext appContext): base(appContext) { }

        public async Task<bool> GetExistingSupplier(string documentNumber)
        {
            var result = await _dbSet.FirstOrDefaultAsync(s => s.Document.Number == documentNumber);

            return result == null ? false : true;
        }

    }
}
