using Shop.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace Shop.Domain.Commands.ProductCommands
{
    public class UpdateProductCommand : Notifiable, ICommand
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool Active { get; private set; }
        public decimal Price { get; private set; }
        public string ImageUrl { get; private set; }
        public int StockQuantity { get; private set; }

        public UpdateProductCommand(string id, string name, string description, bool active, decimal price,
        string imageUrl, int stockQuantity)
        {
            Id = id;
            Name = name;
            Description = description;
            Active = active;
            Price = price;
            ImageUrl = imageUrl;
            StockQuantity = stockQuantity;
        }

        public bool Validation()
        {
            AddNotifications(new ValidationContract()
            .HasMinLen(Name, 1, "Title", "O campo Título não pode ser vazio")
            .HasMaxLen(Name, 250, "Title", "O campo Cidade não pode ter mais que 255 caracteres")
            .HasMinLen(Description, 1, "Description", "O campo Descrição não pode ser vazio")
            .HasMaxLen(Description, 500, "Description", "O campo Descrição não pode ter mais que 500 caracteres")
            .HasMinLen(ImageUrl, 1, "ImageUrl", "O campo Imagem não pode ser vazio")
            .HasMaxLen(ImageUrl, 250, "ImageUrl", "O campo Imagem não pode ter mais que 250 caracteres")
            .IsUrl(ImageUrl, "ImageUrl", "O campo Imagem precisa ser uma URL")
            .IsGreaterThan(StockQuantity, 0, "StockQuantity", "Você precisa ter no mínimo um produto em estoque")
            .Matchs(Price.ToString(), @"^\d{0,8}(.\d{1,2})?$", "Price", "O campo Preço está inválido")
            );
            return Valid;
        }
    }
}