using System.Collections.Generic;
using System.Linq;
using FluentValidator.Validation;
using Shop.Domain.ValueObjects;
using Shop.Shared.Entities;

namespace Shop.Domain.Entities
{
    public class Customer : Entity
    {
        public Customer(TName name, TDocument document, TEmail email, Address address)
        {
            Name = name;
            Document = document;
            Email = email;
            Address = address;
        }

        public Customer(Guid id, TName name, TDocument document, TEmail email, Address address)
        {
            Id = id;
            Name = name;
            Document = document;
            Email = email;
            Address = address;
        }

        public TName Name { get; private set; }
        public TDocument Document { get; private set; }
        public TEmail Email { get; private set; }
        public Address Address { get; private set; }
    }
}
