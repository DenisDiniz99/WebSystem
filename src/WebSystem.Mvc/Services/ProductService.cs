using FluentValidation;
using WebSystem.Mvc.Interfaces;
using WebSystem.Mvc.Models;

namespace WebSystem.Mvc.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly AbstractValidator<Product> _validator;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository, ISupplierRepository supplierRepository, AbstractValidator<Product> validator)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _supplierRepository = supplierRepository;
            _validator = validator;
        }

        public async Task ServiceSaveAsync(string name, string description, decimal price, string image, Guid categoryId, Guid supplierId)
        {
            var product = new Product(name, description, price, image, categoryId, supplierId);

            if (!_validator.Validate(product).IsValid)
                return;

            var supplier = await _supplierRepository.GetByIdAsync(supplierId);

            supplier.AddProduct(product.Id, name, description, price, image, categoryId, supplierId);

            await _productRepository.SaveAsync(product);
        }

        public async Task ServiceUpdateAsync(Guid id, string name, string description, decimal price)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
                return;

            product.UpdateProduct(name, description, price);

            if (!_validator.Validate(product).IsValid)
                return;

            await _productRepository.UpdateAsync(product);
        }

        public async Task ServiceUpdateCategoryAsync(Guid id, Guid categoryId)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
                return;

            var category = await _categoryRepository.GetByIdAsync(categoryId);

            if (category == null)
                return;

            product.UpdateCategory(category);

            await _productRepository.UpdateAsync(product);
        }

        public async Task ServiceUpdateImageAsync(Guid id, string image)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
                return;

            product.UpdateImage(image);

            if (!_validator.Validate(product).IsValid)
                return;

            await _productRepository.UpdateAsync(product);
        }

        public async Task ServiceUpdateSupplierAsync(Guid id, Guid supplierId)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
                return;

            var supplier = await _supplierRepository.GetByIdAsync(supplierId);

            if (supplier == null)
                return;

            product.UpdateSupplier(supplier);

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
