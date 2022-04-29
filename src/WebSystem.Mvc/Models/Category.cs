namespace WebSystem.Mvc.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; private set; }

        public Category(string name)
        {
            Name = name;
        }
    }
}
