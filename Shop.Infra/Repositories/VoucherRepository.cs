using Shop.Domain.Entities;
using Shop.Domain.Repositories;
using Shop.Infra.Data;
using Dapper;
using System;
using System.Linq;
using System.Collections.Generic;
using Shop.Domain.Queries;
using System.Threading.Tasks;

namespace Shop.Infra.Repositories
{
    public class VoucherRepository : IVoucherRepository
    {
        private readonly ShopDataContext _context;

        public VoucherRepository(ShopDataContext context)
        {
            _context = context;
        }

        public async Task Delete(Guid id)
        {
            await _context.Connection.QueryAsync(
               "DELETE FROM [Voucher] WHERE [Id] = @id", new { id = id });
        }

        public async Task<IEnumerable<ListVoucherQueryResult>> Get()
        {
            var result = await _context.Connection
            .QueryAsync<ListVoucherQueryResult>(
            @"SELECT * FROM [Voucher]");

            return result;
        }

        public async Task<GetVoucherQueryResult> GetById(Guid id)
        {
            var result = await _context.Connection
            .QueryFirstOrDefaultAsync<GetVoucherQueryResult>(
            @"SELECT * FROM [Voucher] WHERE Id = @id", new { id = id });

            return result;
        }

        public async Task Update(Voucher voucher)
        {
            await _context.Connection.ExecuteAsync(
                @"UPDATE [Voucher] SET Code = @Code, Percent = @Percent,
                DiscountValue = @DiscountValue, Quantity = @Quantity, DiscountType = @DiscountType, 
                Active = @Active, Used = @Used, ExpiryOn = @ExpiryOn, UpdatedOn = @UpdatedOn
                WHERE Id = @Id",
              new
              {
                  Code = voucher.Code,
                  Percent = voucher.DiscountPercent,
                  DiscountValue = voucher.DiscountValue,
                  Quantity = voucher.Quantity,
                  DiscountType = voucher.DiscountType,
                  Active = voucher.Active,
                  Used = voucher.Used,
                  ExpiryOn = voucher.ExpiryOn,
                  UpdatedOn = DateTime.Now
              });
        }

        public async Task Save(Voucher voucher)
        {
            await _context.Connection.ExecuteAsync(
             @"INSERT INTO [Voucher] VALUES (@Id, @Code, @Percent, @DiscountValue, @Quantity,
             @DiscountType, @Active, @Used, NULL, @ExpiryOn, @CreatedOn, @UpdatedOn)",
             new
             {
                 Id = voucher.Id,
                 Code = voucher.Code,
                 Percent = voucher.DiscountPercent,
                 DiscountValue = voucher.DiscountValue,
                 Quantity = voucher.Quantity,
                 DiscountType = voucher.DiscountType,
                 Active = voucher.Active,
                 Used = voucher.Used,
                 ExpiryOn = voucher.ExpiryOn,
                 CreatedOn = DateTime.Now,
                 UpdatedOn = DateTime.Now
             });

        }
    }
}
