using WebSystem.Mvc.Core.ValuesObject;

namespace WebSystem.Mvc.Core.Interfaces
{
    public interface ISupplierService
    {
        Task ServiceSaveAsync(string name, string corporateName, string description, string phone, string contact, Email email, Document document, Address address);
        Task ServiceUpdateAsync(Guid id, string name, string corporateName, string description, string phone, string contact);
        Task ServiceUpdateEmailAsync(Guid id, string emailAddress);
        Task ServiceUpdateDocumentAsync(Guid id, int documentType, string documentNumber);
        Task ServiceUpdateAddressAsync(Guid id, string street, string number, string neighborhood, string city, string state, string zipcode);
        Task ServiceActivateAsync(Guid id);
        Task ServiceDeactivateAsync(Guid id);
        Task ServiceDeleteAsync(Guid id);
    }
}
