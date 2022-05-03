namespace WebSystem.Mvc.Interfaces
{
    public interface IProductService
    {
        Task ServiceSaveAsync(string name, string description, decimal price, string image, Guid categoryId, Guid supplierId);
        Task ServiceUpdateAsync(Guid id, string name, string description, decimal price);
        Task ServiceUpdateImageAsync(Guid id, string image);
        Task ServiceUpdateCategoryAsync(Guid id, Guid categoryId);
        Task ServiceUpdateSupplierAsync(Guid id, Guid supplierId);
        Task ServiceActivateAsync(Guid id);
        Task ServiceDeactivateAsync(Guid id);
        Task ServiceDeleteAsync(Guid id);
    }
}
