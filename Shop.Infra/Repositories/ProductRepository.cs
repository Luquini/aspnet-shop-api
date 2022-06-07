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
    public class ProductRepository : IProductRepository
    {
        private readonly ShopDataContext _context;

        public ProductRepository(ShopDataContext context)
        {
            _context = context;
        }

        public async Task Delete(Guid id)
        {
            await _context.Connection.QueryAsync(
               "DELETE FROM [Product] WHERE [Id] = @id", new { id = id });
        }

        public async Task<IEnumerable<ListProductQueryResult>> Get()
        {
            var result = await _context.Connection
            .QueryAsync<ListProductQueryResult>(
            @"SELECT * FROM [Product]");

            return result;
        }

        public async Task<GetProductQueryResult> GetById(Guid id)
        {
            var result = await _context.Connection
            .QueryFirstOrDefaultAsync<GetProductQueryResult>(
            @"SELECT * FROM [Product] WHERE Id = @id", new { id = id });

            return result;
        }

        public async Task Update(Product product)
        {
            await _context.Connection.ExecuteAsync(
                @"UPDATE [Product] SET Name = @Name, Description = @Description,
                Active = @Active, Price = @Price, ImageUrl = @ImageUrl, 
                StockQuantity = @StockQuantity, UpdatedOn = @UpdatedOn WHERE Id = @Id",
              new
              {
                  Id = product.Id,
                  Name = product.Name,
                  Description = product.Description,
                  Active = product.Active,
                  Price = product.Price,
                  ImageUrl = product.ImageUrl,
                  StockQuantity = product.StockQuantity,
                  UpdatedOn = DateTime.Now,
              });
        }

        public async Task Save(Product product)
        {
            await _context.Connection.ExecuteAsync(
             @"INSERT INTO [Product] VALUES (@Id, @Name, @Description, @Active, @Price,
             @ImageUrl, @StockQuantity, @CreatedOn, @UpdatedOn)",
             new
             {
                 Id = product.Id,
                 Name = product.Name,
                 Description = product.Description,
                 Active = product.Active,
                 Price = product.Price,
                 ImageUrl = product.ImageUrl,
                 StockQuantity = product.StockQuantity,
                 CreatedOn = DateTime.Now,
                 UpdatedOn = DateTime.Now,
             });

        }
    }
}
