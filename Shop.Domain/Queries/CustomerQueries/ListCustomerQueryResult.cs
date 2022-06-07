using Shop.Domain.Entities;

namespace Shop.Domain.Queries
{
    public class ListCustomerQueryResult
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public AddressQueryResult Address { get; set; }

        public ListCustomerQueryResult(Guid id, string firstName, string lastName, string document,
        string email, DateTime createdOn, DateTime updatedOn)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Document = document;
            Email = email;
            CreatedOn = createdOn;
            UpdatedOn = updatedOn;
            Address = new AddressQueryResult();
        }
    }
}