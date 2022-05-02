using WebSystem.Mvc.ValuesObject;

namespace WebSystem.Mvc.Interfaces
{
    public interface ISupplierService
    {
        Task ServiceSaveAsync(string name, string corporateName, string description, string phone, string contact, Email email, Document document, Address address);
        Task ServiceUpdateAsync(Guid id, string name, string corporateName, string description, string phone, string contact, Email email, Document document, Address address);
        Task ServiceDeleteAsync(Guid id);
        Task ServiceAddProductToSupplier(Guid productId, string name, string description, decimal price, string image, Guid categoryId, Guid supplierId);
    }
}
