using Shop.Shared.Entities;

namespace Shop.Domain.Entities
{
    public class Product : Entity
    {
        public Product(string title, string imageUrl, string description, int stock, decimal price)
        {
            Title = title;
            ImageUrl = imageUrl;
            Description = description;
            Stock = stock;
            Price = price;
        }

        public string Title { get; private set; }
        public string ImageUrl { get; private set; }
        public string Description { get; private set; }
        public int Stock { get; private set; }
        public decimal Price { get; private set; }
    }
}
