using Shop.Shared.Commands;
using FluentValidator;
using Shop.Domain.Entities;

namespace Shop.Domain.Commands.CustomerCommands
{
    public class CreateCustomerCommand : Notifiable, ICommand
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public Address Address { get; private set; }

        public CreateCustomerCommand(string firstName, string lastName, string document, string email, Address address)
        {
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
            return Valid;
        }

    }
}
