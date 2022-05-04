using WebSystem.Mvc.Core.Interfaces;
using WebSystem.Mvc.Core.Models;

namespace WebSystem.Mvc.Infrastructure.Data.Repositories
{
    public class SupplierRepository : BaseRepositoy<Supplier>, ISupplierRepository
    {
        public SupplierRepository(AppContext appContext): base(appContext) { }
    }
}
