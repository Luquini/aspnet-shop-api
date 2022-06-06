using FluentValidator.Validation;
using Shop.Shared.ValueObjects;

namespace Shop.Domain.ValueObjects
{
    public class TEmail : ValueObject
    {
        public TEmail(string address)
        {
            AddNotifications(new ValidationContract()
            .IsEmail(address, "Email", "Email invalido")
            .HasMinLen(address, 1, "Email", "O campo Email não pode ser vazio")
            .HasMaxLen(address, 160, "Email", "O campo Email não pode ter mais que 160 caracteres")
            );
            Address = address;
        }
        public string Address { get; private set; }
    }
}
