namespace WebSystem.Mvc.Core.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public string Image { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public bool Active { get; private set; }
        public Guid CategoryId { get; private set; }
        public Category Category { get; private set; }
        public Guid SupplierId { get; private set; }
        public Supplier Supplier { get; private set; }

        public Product() { }

        public Product(string name, string description, decimal price, string image, Guid categoryId, Guid supplierId)
        {
            Name = name;
            Description = description;
            Price = price;
            Image = image;
            CategoryId = categoryId;
            SupplierId = supplierId;
            RegistrationDate = DateTime.Now.Date;
            Active = true;
        }

        public void Activate()
        {
            Active = true;
        }

        public void Deactivate()
        {
            Active = false;
        }

        public void UpdateImage(string image)
        {
            Image = image;
        }

        public void UpdateCategory(Category category)
        {
            Category = category;
        }

        public void UpdateSupplier(Supplier supplier)
        {
            Supplier = supplier;
        }

        public void UpdateProduct(string name, string description, decimal price)
        {
            Name = name;
            Description= description;
            Price = price;
        }
    }
}
