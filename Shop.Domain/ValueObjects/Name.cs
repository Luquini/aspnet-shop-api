using FluentValidator.Validation;
using Shop.Shared.ValueObjects;

namespace Shop.Domain.ValueObjects
{
    public class TName : ValueObject
    {
        public TName(string firstName, string lastName)
        {
            AddNotifications(new ValidationContract()
           .HasMinLen(firstName, 3, "FirstName", "O nome deve ter pelo menos 3 caracteres")
           .HasMaxLen(firstName, 40, "FirstName", "O nome deve ter no máximo 40 caracteres")
           .HasMinLen(lastName, 3, "LastName", "O sobrenome deve ter pelo menos 3 caracteres")
           .HasMaxLen(lastName, 40, "LastName", "O sobrenome deve ter no máximo 40 caracteres"));
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}";
        }
    }
}
