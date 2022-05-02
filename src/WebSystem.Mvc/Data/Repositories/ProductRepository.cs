using WebSystem.Mvc.Interfaces;
using WebSystem.Mvc.Models;

namespace WebSystem.Mvc.Data.Repositories
{
    public class ProductRepository : BaseRepositoy<Product>, IProductRepository
    {
        public ProductRepository(AppContext appContext) : base(appContext) { }
    }
}
