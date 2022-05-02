using WebSystem.Mvc.Interfaces;
using WebSystem.Mvc.Models;

namespace WebSystem.Mvc.Data.Repositories
{
    public class CategoryRepository : BaseRepositoy<Category>, ICategoryRepository
    {
        public CategoryRepository(AppContext appContext) : base(appContext) { }
    }
}
