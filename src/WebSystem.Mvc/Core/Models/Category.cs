namespace WebSystem.Mvc.Core.Models
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


        public void UpdateCategory(string name)
        {
            Name=name;
        }
    }
}
