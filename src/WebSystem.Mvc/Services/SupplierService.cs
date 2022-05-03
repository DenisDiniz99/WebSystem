using FluentValidation;
using WebSystem.Mvc.Enums;
using WebSystem.Mvc.Interfaces;
using WebSystem.Mvc.Models;
using WebSystem.Mvc.ValuesObject;

namespace WebSystem.Mvc.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IProductRepository _productRepository;
        private readonly AbstractValidator<Supplier> _validator;

        public SupplierService(ISupplierRepository supplierRepository, IProductRepository productRepository, AbstractValidator<Supplier> validator)
        {
            _supplierRepository = supplierRepository;
            _productRepository = productRepository;
            _validator = validator;
        }

        public async Task ServiceSaveAsync(string name, string corporateName, string description, string phone, string contact, Email email, Document document, Address address)
        {
            var supplier = new Supplier(name, corporateName, description, phone, contact, email, document, address);

            if (!_validator.Validate(supplier).IsValid)
                return;

            await _supplierRepository.SaveAsync(supplier);
        }

        public async Task ServiceUpdateAsync(Guid id, string name, string corporateName, string description, string phone, string contact)
        {
            var supplier = await _supplierRepository.GetByIdAsync(id);

            if (supplier == null)
                return;

            supplier.UpdateSupplier(name, corporateName, description, phone, contact);

            if (!_validator.Validate(supplier).IsValid)
                return;

            await _supplierRepository.UpdateAsync(supplier);
        }

        public async Task ServiceUpdateEmailAsync(Guid id, string emailAddress)
        {
            var supplier = await _supplierRepository.GetByIdAsync(id);

            if (supplier == null)
                return;

            var email = new Email(emailAddress);

            supplier.UpdateEmail(email);

            if (!_validator.Validate(supplier).IsValid)
                return;

            await _supplierRepository.UpdateAsync(supplier);
        }

        public async Task ServiceUpdateDocumentAsync(Guid id, int documentType, string documentNumber)
        {
            var supplier = await _supplierRepository.GetByIdAsync(id);

            if (supplier == null)
                return;

            var document = new Document((EDocumentType)documentType, documentNumber);

            supplier.UpdateDocument(document);

            if (!_validator.Validate(supplier).IsValid)
                return;

            await _supplierRepository.UpdateAsync(supplier);
        }

        public async Task ServiceUpdateAddressAsync(Guid id, string street, string number, string neighborhood, string city, string state, string zipcode)
        {
            var supplier = await _supplierRepository.GetByIdAsync(id);

            if (supplier == null)
                return;

            var address = new Address(street, number, neighborhood, city, state, zipcode);

            supplier.UpdateAddress(address);

            if (!_validator.Validate(supplier).IsValid)
                return;

            await _supplierRepository.UpdateAsync(supplier);
        }

        public async Task ServiceActivateAsync(Guid id)
        {
            var supplier = await _supplierRepository.GetByIdAsync(id);

            if (supplier == null)
                return;

            supplier.Activate();

            await _supplierRepository.UpdateAsync(supplier);
        }

        public async Task ServiceDeactivateAsync(Guid id)
        {
            var supplier = await _supplierRepository.GetByIdAsync(id);

            if (supplier == null)
                return;

            supplier.Deactivate();

            await _supplierRepository.UpdateAsync(supplier);
        }

        public async Task ServiceDeleteAsync(Guid id)
        {
            if (id == Guid.Empty)
                return;

            await _supplierRepository.DeleteAsync(id);
        }
    }
}