using Shop.Shared.Entities;

namespace Shop.Domain.Entities
{
    public class Voucher : Entity
    {
        public string Code { get; private set; }
        public decimal Percent { get; private set; }
        public decimal DiscountValue { get; private set; }
        public int Quantity { get; private set; }
        public int DiscountType { get; private set; }
        public bool Active { get; private set; }
        public bool Used { get; private set; }
        public DateTime ExpiryOn { get; private set; }
        public Voucher(string code, decimal percent, decimal discountValue,
        int quantity, int discountType, bool active, bool used,
        DateTime expiryOn)
        {
            Code = code;
            Percent = percent;
            DiscountValue = discountValue;
            Quantity = quantity;
            DiscountType = discountType;
            Active = active;
            Used = used;
            ExpiryOn = expiryOn;
        }

        public Voucher(Guid id, string code, decimal percent, decimal discountValue,
        int quantity, int discountType, bool active, bool used,
        DateTime expiryOn)
        {
            Id = id;
            Code = code;
            Percent = percent;
            DiscountValue = discountValue;
            Quantity = quantity;
            DiscountType = discountType;
            Active = active;
            Used = used;
            ExpiryOn = expiryOn;
        }
    }
}