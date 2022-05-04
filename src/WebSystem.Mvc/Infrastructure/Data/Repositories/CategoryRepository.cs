using WebSystem.Mvc.Core.Interfaces;
using WebSystem.Mvc.Core.Models;

namespace WebSystem.Mvc.Infrastructure.Data.Repositories
{
    public class CategoryRepository : BaseRepositoy<Category>, ICategoryRepository
    {
        public CategoryRepository(AppContext appContext) : base(appContext) { }
    }
}
