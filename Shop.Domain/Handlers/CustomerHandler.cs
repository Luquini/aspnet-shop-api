using FluentValidator;
using Shop.Domain.Commands;
using Shop.Domain.Commands.CustomerCommands;
using Shop.Domain.Entities;
using Shop.Domain.Enums;
using Shop.Domain.Repositories;
using Shop.Domain.ValueObjects;
using Shop.Shared.Commands;

namespace Shop.Domain.Handlers
{
    public class CustomerHandler : Notifiable,
    ICommandHandler<CreateCustomerCommand>,
    ICommandHandler<UpdateCustomerCommand>
    {
        private readonly ICustomerRepository _repository;
        public CustomerHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICommandResult> Handle(CreateCustomerCommand command)
        {
            try
            {
                command.Validation();

                if (await _repository.CheckDocument(command.Document))
                    AddNotification("Document", "Esse CPF já foi cadastrado");

                if (await _repository.CheckEmail(command.Email))
                    AddNotification("Email", "Esse Email já foi cadastrado");

                var name = new TName(command.FirstName, command.LastName);
                var document = new TDocument(command.Document, EDocumentType.CPF);
                var email = new TEmail(command.Email);

                var customer = new Customer(name, document, email, command.Address);

                AddNotifications(command.Notifications);
                AddNotifications(name.Notifications);
                AddNotifications(document.Notifications);
                AddNotifications(email.Notifications);
                AddNotifications(customer.Notifications);

                if (Invalid)
                    return new CommandResult(
                        false,
                        "Favor corrigir os campos abaixo",
                        Notifications);

                await _repository.Save(customer);

                return new CommandResult(true, "Cliente cadastrado com sucesso!", new
                {
                    Id = customer.Id,
                    Name = name.ToString(),
                    Email = email.Address
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

        public async Task<ICommandResult> Handle(UpdateCustomerCommand command)
        {
            try
            {
                command.Validation();

                var name = new TName(command.FirstName, command.LastName);
                var document = new TDocument(command.Document, EDocumentType.CPF);
                var email = new TEmail(command.Email);
                var id = Guid.Parse(command.Id);

                var customer = new Customer(id, name, document, email, command.Address);

                AddNotifications(command.Notifications);
                AddNotifications(name.Notifications);
                AddNotifications(document.Notifications);
                AddNotifications(email.Notifications);
                AddNotifications(customer.Notifications);

                if (Invalid)
                    return new CommandResult(
                        false,
                        "Favor corrigir os campos abaixo",
                        Notifications);

                await _repository.Update(customer);

                return new CommandResult(true, "Cliente atualizado com sucesso!", new
                {
                    Id = customer.Id,
                    Name = name.ToString(),
                    Email = email.Address
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
