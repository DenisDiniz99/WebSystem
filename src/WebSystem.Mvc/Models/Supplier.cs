using WebSystem.Mvc.ValuesObject;

namespace WebSystem.Mvc.Models
{
    public class Supplier : BaseEntity
    {
        public string Name { get; private set; }
        public string CorporateName { get; private set; }
        public string Description { get; private set; }
        public string Phone { get; private set; }
        public string Contact { get; private set; }
        public Email Email { get; private set; }
        public Document Document { get; private set; }
        public Address Address { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public bool Active { get; private set; }

        private readonly List<Product> _products = new List<Product>();
        public IReadOnlyCollection<Product> Products => _products;

        public Supplier() { }
        public Supplier(string name, string corporateName, string description, string phone, string contact, Email email, Document document, Address address)
        {
            Name = name;
            CorporateName = corporateName;
            Description = description;
            Phone = phone;
            Contact = contact;
            Email = email;
            Document = document;
            Address = address;
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

        public void AddProduct(Guid productId, string name, string description, decimal price, string image, Guid categoryId, Guid supplierId)
        {
            if(!Products.Any(p => p.Id == productId))
            {
                _products.Add(new Product(name, description, price, image, categoryId, supplierId));
                return;
            }
            var productExiting = Products.FirstOrDefault(p => p.Id == productId);
            productExiting.UpdateProduct(name, description, price, image, categoryId, supplierId);
        }

        public void UpdateAddress(Address address)
        {
            Address = address;
        }

        public void UpdateEmail(Email email)
        {
            Email = email;
        }

        public void UpdateDocument(Document document)
        {
            Document = document;
        }
    }
}