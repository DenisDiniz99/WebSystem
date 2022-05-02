namespace WebSystem.Mvc.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; private set; }

        public readonly List<Product> _products = new List<Product>();
        public IReadOnlyCollection<Product> Products => _products.AsReadOnly();

        public Category(){ }

        public Category(string name)
        {
            Name = name;
        }

        public void AddProductToCategory(string name, string description, decimal price, string image, Guid categoryId, Guid supplierId)
        {
            var product = new  Product(name, description, price, image, categoryId, supplierId);
            _products.Add(product);
        }
    }
}
