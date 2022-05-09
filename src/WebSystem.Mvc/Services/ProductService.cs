using WebSystem.Mvc.Core.Interfaces;
using WebSystem.Mvc.Core.Models;
using WebSystem.Mvc.Core.Validations;

namespace WebSystem.Mvc.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISupplierRepository _supplierRepository;
        private ProductValidator validator;

        public ProductService(IProductRepository productRepository,
                                ICategoryRepository categoryRepository,
                                ISupplierRepository supplierRepository,
                                IHandleNotification handle) : base(handle)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _supplierRepository = supplierRepository;
            validator = new ProductValidator();
        }

        public async Task ServiceSaveAsync(string name, string description, decimal price, string image, Guid categoryId, Guid supplierId)
        {
            var product = new Product(name, description, price, image, categoryId, supplierId);

            var result = validator.Validate(product);

            if (!result.IsValid)
            {
                Execute(result);
                return;
            }

            var supplier = await _supplierRepository.GetByIdAsync(supplierId);

            supplier.AddProduct(product.Id, name, description, price, image, categoryId, supplierId);

            await _productRepository.SaveAsync(product);
        }

        public async Task ServiceUpdateAsync(Guid id, string name, string description, decimal price, string image, Guid categoryId, Guid supplierId)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
                return;

            product.UpdateProduct(name, description, price, image, categoryId, supplierId);

            var result = validator.Validate(product);

            if (!result.IsValid)
            {
                Execute(result);
                return;
            }

            await _productRepository.UpdateAsync(product);
        }

        public async Task ServiceActivateAsync(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
                return;

            product.Activate();

            await _productRepository.UpdateAsync(product);
        }

        public async Task ServiceDeactivateAsync(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
                return;

            product.Deactivate();

            await _productRepository.UpdateAsync(product);
        }

        public async Task ServiceDeleteAsync(Guid id)
        {
            if (id == Guid.Empty)
                return;

            await _productRepository.DeleteAsync(id);
        }
    }
}
