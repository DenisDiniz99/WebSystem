using FluentValidation;
using WebSystem.Mvc.Core.Interfaces;
using WebSystem.Mvc.Core.Models;

namespace WebSystem.Mvc.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly AbstractValidator<Category> _validator;


        public CategoryService(ICategoryRepository categoryRepository, AbstractValidator<Category> validator)
        {
            _categoryRepository = categoryRepository;
            _validator = validator;
        }

        public async Task ServiceSaveAsync(string categoryName)
        {
            var category = new Category(categoryName);

            if (!_validator.Validate(category).IsValid)
                return;

            await _categoryRepository.SaveAsync(category);
        }

        public async Task ServiceUpdateAsync(Guid categoryId, string categoryName)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId);

            if (category == null)
                return;

            category.UpdateCategory(categoryName);

            if (!_validator.Validate(category).IsValid)
                return;

            await _categoryRepository.UpdateAsync(category);
        }

        public async Task ServiceDeleteAsync(Guid categoryId)
        {
            if (categoryId == Guid.Empty)
                return;

            await _categoryRepository.DeleteAsync(categoryId);
        }
    }
}
