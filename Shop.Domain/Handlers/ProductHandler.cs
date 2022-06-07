using FluentValidator;
using Shop.Domain.Commands;
using Shop.Domain.Commands.CustomerCommands;
using Shop.Domain.Commands.ProductCommands;
using Shop.Domain.Entities;
using Shop.Domain.Enums;
using Shop.Domain.Repositories;
using Shop.Domain.ValueObjects;
using Shop.Shared.Commands;

namespace Shop.Domain.Handlers
{
    public class ProductHandler : Notifiable,
    ICommandHandler<CreateProductCommand>,
    ICommandHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _repository;
        public ProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICommandResult> Handle(CreateProductCommand command)
        {
            try
            {
                command.Validation();

                AddNotifications(command.Notifications);

                var product = new Product(command.Name, command.Description, command.Active,
                command.Price, command.ImageUrl, command.StockQuantity);

                if (Invalid)
                    return new CommandResult(
                        false,
                        "Favor corrigir os campos abaixo",
                        Notifications);

                await _repository.Save(product);

                return new CommandResult(true, "Produto cadastrado com sucesso!", new
                {
                    Id = product.Id,
                    Name = product.Name
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new CommandResult(
                false,
                "Erro ao processar os campos da requisição",
                Notifications);
            }
        }

        public async Task<ICommandResult> Handle(UpdateProductCommand command)
        {
            try
            {
                command.Validation();

                AddNotifications(command.Notifications);

                var id = Guid.Parse(command.Id);

                var product = new Product(id, command.Name, command.Description, command.Active,
                command.Price, command.ImageUrl, command.StockQuantity);

                if (Invalid)
                    return new CommandResult(
                        false,
                        "Favor corrigir os campos abaixo",
                        Notifications);

                await _repository.Update(product);

                return new CommandResult(true, "Produto cadastrado com sucesso!", new
                {
                    Id = product.Id,
                    Name = product.Name
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new CommandResult(
                false,
                "Erro ao processar os campos da requisição",
                Notifications);
            }
        }
    }
}