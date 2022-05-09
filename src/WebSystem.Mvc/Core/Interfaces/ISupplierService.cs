using WebSystem.Mvc.Core.ValuesObject;

namespace WebSystem.Mvc.Core.Interfaces
{
    public interface ISupplierService
    {
        Task ServiceSaveAsync(string name, string corporateName, string description, string phone, string contact, Email email, Document document, Address address);
        Task ServiceUpdateAsync(Guid id, string name, string corporateName, string description, string phone, string contact, Email email, Document document);
        Task ServiceUpdateAddressAsync(Guid id, string street, string number, string neighborhood, string city, string state, string zip);
        Task ServiceActivateAsync(Guid id);
        Task ServiceDeactivateAsync(Guid id);
        Task ServiceDeleteAsync(Guid id);
    }
}
