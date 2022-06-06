using Shop.Domain.Entities;
using Shop.Domain.Queries;

namespace Shop.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task Delete(Guid id);
        Task<IEnumerable<ListCustomerQueryResult>> Get();
        Task<GetCustomerQueryResult> GetById(Guid id);
        Task Save(Customer customer);
        Task Update(Customer customer);
        Task<bool> CheckEmail(string email);
        Task<bool> CheckDocument(string document);
    }
}
