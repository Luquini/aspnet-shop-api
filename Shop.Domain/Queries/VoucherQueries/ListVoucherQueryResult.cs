using Shop.Domain.Entities;

namespace Shop.Domain.Queries
{
    public class ListVoucherQueryResult
    {
        public Guid Id { get; set; }
        public string Code { get; private set; }
        public decimal Percent { get; private set; }
        public decimal DiscountValue { get; private set; }
        public int Quantity { get; private set; }
        public int DiscountType { get; private set; }
        public bool Active { get; private set; }
        public bool Used { get; private set; }
        public DateTime UsedOn { get; private set; }
        public DateTime ExpiryOn { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime UpdatedOn { get; private set; }

        public ListVoucherQueryResult(Guid id, string code, decimal percent,
        decimal discountValue, int quantity, int discountType, bool active, bool used,
        DateTime usedOn, DateTime expiryOn, DateTime createdOn, DateTime updatedOn)
        {
            Id = id;
            Code = code;
            Percent = percent;
            DiscountValue = discountValue;
            Quantity = quantity;
            DiscountType = discountType;
            Active = active;
            Used = used;
            UsedOn = usedOn;
            ExpiryOn = expiryOn;
            CreatedOn = createdOn;
            UpdatedOn = updatedOn;
        }
    }
}