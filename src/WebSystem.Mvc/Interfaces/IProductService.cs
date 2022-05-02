namespace WebSystem.Mvc.Interfaces
{
    public interface IProductService
    {
        Task ServiceSaveAsync(string name, string description, decimal price, string image, Guid categoryId, Guid supplierId);
        Task ServiceUpdateAsync(Guid id, string name, string description, decimal price, string image, Guid categoryId, Guid supplierId);
        Task ServiceDeleteAsync(Guid id);
    }
}
