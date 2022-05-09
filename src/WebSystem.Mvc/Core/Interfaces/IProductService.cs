using WebSystem.Mvc.Core.Models;

namespace WebSystem.Mvc.Core.Interfaces
{
    public interface IProductService
    {
        Task ServiceSaveAsync(string name, string description, decimal price, string image, Guid categoryId, Guid supplierId);
        Task ServiceUpdateAsync(Guid id, string name, string description, decimal price, string image, Guid categoryId, Guid supplierId);
        Task ServiceActivateAsync(Guid id);
        Task ServiceDeactivateAsync(Guid id);
        Task ServiceDeleteAsync(Guid id);
    }
}
