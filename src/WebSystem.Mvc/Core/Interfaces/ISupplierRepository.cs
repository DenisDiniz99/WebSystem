using WebSystem.Mvc.Core.Models;

namespace WebSystem.Mvc.Core.Interfaces
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        Task<bool> GetExistingSupplier(string documentNumber);
    }
}