using Shop.Shared.Entities;

namespace Shop.Domain.Entities
{
    public class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool Active { get; private set; }
        public decimal Price { get; private set; }
        public string ImageUrl { get; private set; }
        public int StockQuantity { get; private set; }

        public Product(string name, string description, bool active, decimal price, string imageUrl,
        int stockQuantity)
        {
            Name = name;
            Description = description;
            Active = active;
            Price = price;
            ImageUrl = imageUrl;
            StockQuantity = stockQuantity;
        }
        public Product(Guid id, string name, string description, bool active, decimal price, string imageUrl,
        int stockQuantity)
        {
            Id = id;
            Name = name;
            Description = description;
            Active = active;
            Price = price;
            ImageUrl = imageUrl;
            StockQuantity = stockQuantity;
        }
    }
}
