using WebSystem.Mvc.Core.Interfaces;
using WebSystem.Mvc.Core.Models;
using WebSystem.Mvc.Core.Validations;
using WebSystem.Mvc.Core.ValuesObject;

namespace WebSystem.Mvc.Services
{
    public class SupplierService : BaseService, ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IProductRepository _productRepository;
        private SupplierValidator validator;

        public SupplierService(ISupplierRepository supplierRepository, 
                                IProductRepository productRepository,
                                IHandleNotification handle) : base(handle)
        {
            _supplierRepository = supplierRepository;
            _productRepository = productRepository;
            validator = new SupplierValidator();
        }

        public async Task ServiceSaveAsync(string name, string corporateName, string description, string phone, string contact, Email email, Document document, Address address)
        {
            var supplier = new Supplier(name, corporateName, description, phone, contact, email, document, address);

            var result = validator.Validate(supplier);

            if (!result.IsValid)
            {
                Execute(result);
                return;
            }

            await _supplierRepository.SaveAsync(supplier);
        }

        public async Task ServiceUpdateAsync(Guid id, string name, string corporateName, string description, string phone, string contact,Email email,Document document)
        {
            var supplier = await _supplierRepository.GetByIdAsync(id);

            if (supplier == null)
                return;

            supplier.UpdateSupplier(name, corporateName, description, phone, contact, email, document);

            var result = validator.Validate(supplier);

            if (!result.IsValid)
            {
                Execute(result);
                return;
            }

            await _supplierRepository.UpdateAsync(supplier);
        }


        public async Task ServiceUpdateAddressAsync(Guid id, string street, string number, string neighborhood, string city, string state, string zipcode)
        {
            var supplier = await _supplierRepository.GetByIdAsync(id);

            if (supplier == null)
                return;

            var address = new Address(street, number, neighborhood, city, state, zipcode);

            supplier.UpdateAddress(address);

            var result = validator.Validate(supplier);

            if (!result.IsValid)
            {
                Execute(result);
                return;
            }

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