using WebSystem.Mvc.Interfaces;
using WebSystem.Mvc.Models;

namespace WebSystem.Mvc.Data.Repositories
{
    public class SupplierRepository : BaseRepositoy<Supplier>, ISupplierRepository
    {
        public SupplierRepository(AppContext appContext): base(appContext) { }
    }
}
