using Shop.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace Shop.Domain.Commands.ProductCommands
{
    public class UpdateVoucherCommand : Notifiable, ICommand
    {
        public string Id { get; private set; }
        public string Code { get; private set; }
        public decimal DiscountPercent { get; private set; }
        public decimal DiscountValue { get; private set; }
        public int Quantity { get; private set; }
        public int DiscountType { get; private set; }
        public bool Active { get; private set; }
        public bool Used { get; private set; }
        public DateTime ExpiryOn { get; private set; }

        public UpdateVoucherCommand(string id, string code, decimal discountPercent, decimal discountValue,
        int quantity, int discountType, bool active, bool used, DateTime expiryOn)
        {
            Id = id;
            Code = code;
            DiscountPercent = discountPercent;
            DiscountValue = discountValue;
            Quantity = quantity;
            DiscountType = discountType;
            Active = active;
            Used = used;
            ExpiryOn = expiryOn;
        }
        public bool Validation()
        {
            AddNotifications(new ValidationContract()
            .HasMinLen(Code, 1, "Code", "O campo Código não pode ser vazio")
            .HasMaxLen(Code, 100, "Code", "O campo Código não pode ter mais que 100 caracteres")
            .IsBetween(DiscountPercent, 0, 101, "DiscountPercent", "O campo Desconto deve ter um valor válido")
            .IsGreaterThan(DiscountValue, 0, "DiscountValue", "O campo Desconto deve ter um valor válido")
            .IsGreaterThan(Quantity, 0, "Quantity", "O campo Quantidade deve ter um valor válido")
            .IsBetween(DiscountType, 0, 3, "DiscountType", "O campo TipoDesconto deve ter um valor válido")
            .IsGreaterThan(ExpiryOn, DateTime.Now, "ExpiryOn", "O campo Expiração deve ter uma data válida")
            .Matchs(DiscountPercent.ToString(), @"^\d{0,8}(.\d{1,2})?$", "DiscountPercent", "O campo Desconto deve ter um valor válido")
            .Matchs(DiscountValue.ToString(), @"^\d{0,8}(.\d{1,2})?$", "DiscountValue", "O campo Desconto deve ter um valor válido")
            );
            return Valid;
        }
    }
}