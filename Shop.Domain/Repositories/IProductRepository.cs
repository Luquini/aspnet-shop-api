using Shop.Domain.Entities;
using Shop.Domain.Queries;

namespace Shop.Domain.Repositories
{
    public interface IProductRepository
    {
        Task Delete(Guid id);
        Task<IEnumerable<ListProductQueryResult>> Get();
        Task<GetProductQueryResult> GetById(Guid id);
        Task Save(Product product);
        Task Update(Product product);
    }
}
