using Shop.Domain.Entities;
using Shop.Domain.Queries;

namespace Shop.Domain.Repositories
{
    public interface IVoucherRepository
    {
        Task Delete(Guid id);
        Task<IEnumerable<ListVoucherQueryResult>> Get();
        Task<GetVoucherQueryResult> GetById(Guid id);
        Task Save(Voucher voucher);
        Task Update(Voucher voucher);
    }
}
