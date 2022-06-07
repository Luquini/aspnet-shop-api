using Shop.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace Shop.Domain.Commands.ProductCommands
{
    public class CreateProductCommand : Notifiable, ICommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int StockQuantity { get; set; }

        public CreateProductCommand(string name, string description, bool active, decimal price,
        string imageUrl, int stockQuantity)
        {
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
            .IsGreaterThan(StockQuantity, 1, "StockQuantity", "Você precisa ter no mínimo um produto em estoque")
            .Matchs(Price.ToString(), @"^\d{0,10}(.\d{1,2})?$", "Price", "O campo Preço está inválido")
            );
            return !Valid;
        }
    }
}