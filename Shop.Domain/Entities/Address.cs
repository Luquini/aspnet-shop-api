using FluentValidator.Validation;
using Shop.Shared.Entities;

namespace Shop.Domain.Entities
{
    public class Address : Entity
    {
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? Number { get; set; }
        public string? District { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? ZipCode { get; set; }

        public override string ToString()
        {
            return $"{this.Street}, {this.Number} - {this.City}/{this.State}";
        }

        public bool Validation()
        {
            AddNotifications(new ValidationContract()
            .HasMinLen(City, 1, "City", "O campo Cidade não pode ser vazio")
            .HasMaxLen(City, 40, "City", "O campo Cidade não pode ter mais que 40 caracteres")
            .HasMinLen(Street, 1, "Street", "O campo Rua não pode ser vazio")
            .HasMaxLen(Street, 40, "Street", "O campo Rua não pode ter mais que 40 caracteres")
            .HasMinLen(Number, 1, "Number", "O campo Número não pode ser vazio")
            .HasMaxLen(Number, 10, "Number", "O campo Número não pode ter mais que 10 caracteres")
            .HasMinLen(District, 1, "District", "O campo Bairro não pode ser vazio")
            .HasMaxLen(District, 60, "District", "O campo Bairro não pode ter mais que 60 caracteres")
            .HasMinLen(State, 1, "State", "O campo Estado não pode ser vazio")
            .HasMaxLen(State, 2, "State", "O campo Estado não pode ter mais que 2 caracteres")
            .HasMinLen(Country, 1, "Country", "O campo País não pode ser vazio")
            .HasMaxLen(Country, 2, "Country", "O campo País não pode ter mais que 2 caracteres")
            .HasMinLen(ZipCode, 1, "ZipCode", "O campo CEP não pode ser vazio")
            .HasMaxLen(ZipCode, 8, "ZipCode", "O campo CEP não pode ter mais que 8 caracteres")
            .Matchs(ZipCode, @"^\d{5}\d{3}$", "ZipCode", "O campo CEP está inválido")
            );
            return !Valid;
        }

    }
}
