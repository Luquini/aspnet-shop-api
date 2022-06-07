using Shop.Domain.Entities;

namespace Shop.Domain.Queries
{
    public class GetProductQueryResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int StockQuantity { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public GetProductQueryResult(Guid id, string name, string description, bool active,
        decimal price, string imageUrl, int stockQuantity, DateTime createdOn, DateTime updatedOn)
        {
            Id = id;
            Name = name;
            Description = description;
            Active = active;
            Price = price;
            ImageUrl = imageUrl;
            StockQuantity = stockQuantity;
            CreatedOn = createdOn;
            UpdatedOn = updatedOn;
        }
    }
}