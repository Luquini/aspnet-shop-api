using Shop.Shared.ValueObjects;
using Shop.Domain.Enums;
using FluentValidator.Validation;

namespace Shop.Domain.ValueObjects
{
    public class TDocument : ValueObject
    {
        public TDocument(string number, EDocumentType type)
        {
            AddNotifications(new ValidationContract()
            .Matchs(number, @"^\d{3}\d{3}\d{3}\d{2}$", "Document", "O campo CPF está inválido")
            );
            Number = number;
            Type = type;
        }

        public string Number { get; private set; }
        public EDocumentType Type { get; private set; }
    }
}
