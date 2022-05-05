using WebSystem.Mvc.Core.Interfaces;
using WebSystem.Mvc.Core.Models;

namespace WebSystem.Mvc.Infrastructure.Data.Repositories
{
    public class ProductRepository : BaseRepositoy<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext appContext) : base(appContext) { }
    }
}
