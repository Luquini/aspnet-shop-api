using Shop.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;
using Shop.Domain.Entities;
using Shop.Domain.ValueObjects;

namespace Shop.Domain.Commands.CustomerCommands
{
    public class UpdateCustomerCommand : Notifiable, ICommand
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }

        public UpdateCustomerCommand(string id, string firstName, string lastName, string document, string email, Address address)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Document = document;
            Email = email;
            Address = address;
        }

        public bool Validation()
        {
            Address.Validation();
            AddNotifications(Address.Notifications);
            return !Valid;
        }

    }
}
