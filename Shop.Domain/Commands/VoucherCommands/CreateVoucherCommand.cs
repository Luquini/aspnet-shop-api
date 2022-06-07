using Shop.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace Shop.Domain.Commands.ProductCommands
{
    public class CreateVoucherCommand : Notifiable, ICommand
    {
        public string Code { get; set; }
        public decimal Percent { get; set; }
        public decimal DiscountValue { get; set; }
        public int Quantity { get; set; }
        public int DiscountType { get; set; }
        public bool Active { get; set; }
        public bool Used { get; set; }
        public DateTime ExpiryOn { get; set; }

        public CreateVoucherCommand(string code, decimal percent, decimal discountValue,
        int quantity, int discountType, bool active, bool used, DateTime expiryOn)
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
        public bool Validation()
        {
            return !Valid;
        }
    }
}