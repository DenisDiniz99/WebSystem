using WebSystem.Mvc.Core.Interfaces;
using WebSystem.Mvc.Core.Models;
using WebSystem.Mvc.Core.Validations;

namespace WebSystem.Mvc.Services
{
    public class CategoryService : BaseService, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private CategoryValidator validator;


        public CategoryService(ICategoryRepository categoryRepository, 
                                IHandleNotification handle) : base(handle)
        {
            _categoryRepository = categoryRepository;
            validator = new CategoryValidator();
        }

        public async Task ServiceSaveAsync(string categoryName)
        {
            var category = new Category(categoryName);

            var result = validator.Validate(category);

            if (!result.IsValid)
            {
                Execute(result);
                return;
            }
            
            await _categoryRepository.SaveAsync(category);
        }

        public async Task ServiceUpdateAsync(Guid categoryId, string categoryName)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId);

            if (category == null)
                return;

            category.UpdateCategory(categoryName);

            var result = validator.Validate(category);

            if (!result.IsValid)
            {
                Execute(result);
                return;
            }

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
