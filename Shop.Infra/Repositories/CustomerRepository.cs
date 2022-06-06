using Shop.Domain.Entities;
using Shop.Domain.Repositories;
using Shop.Infra.Data;
using Dapper;
using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using Shop.Domain.Queries;
using System.Threading.Tasks;

namespace Shop.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ShopDataContext _context;

        public CustomerRepository(ShopDataContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckDocument(string document)
        {
            return await _context
                .Connection.ExecuteScalarAsync<bool>(
                    "SELECT COUNT(*) FROM [Customer] WHERE Document = @Document",
                    new { Document = document });
        }

        public async Task<bool> CheckEmail(string email)
        {
            return await _context
                .Connection.ExecuteScalarAsync<bool>(
                    "SELECT COUNT(*) FROM [Customer] WHERE Email = @Email",
                    new { Email = email });
        }

        public async Task Delete(Guid id)
        {
            await _context.Connection.QueryAsync(
               "DELETE FROM [Address] WHERE [CustomerId]=@id", new { id = id });

            await _context.Connection.QueryAsync(
               "DELETE FROM [Customer] WHERE [ID]=@id", new { id = id });
        }

        public async Task<IEnumerable<ListCustomerQueryResult>> Get()
        {
            return await _context
             .Connection
             .QueryAsync<ListCustomerQueryResult>(@"SELECT [ID],CONCAT([FirstName],' ',[LastName]) 
             AS [Name], [Document],[Email] from [Customer]",
             new { });
        }

        public async Task<GetCustomerQueryResult> GetById(Guid id)
        {
            return await _context.Connection.QueryFirstOrDefaultAsync<GetCustomerQueryResult>(
            @"SELECT [ID],CONCAT([FirstName],' ',[LastName])
            AS [Name], [Document],[Email] from [Customer] WHERE [ID]=@id",
            new { id = id });
        }

        public async Task Update(Customer customer)
        {
            await _context.Connection.ExecuteAsync(
            @"UPDATE [Customer] SET FirstName = @FirstName, LastName = @LastName, 
            Document = @Document, Email = @Email, UpdatedOn = @UpdatedOn WHERE Id = @Id",
             new
             {
                 Id = customer.Id,
                 FirstName = customer.Name.FirstName,
                 LastName = customer.Name.LastName,
                 Document = customer.Document.Number,
                 Email = customer.Email.Address,
                 UpdatedOn = DateTime.Now,
             });

            await _context.Connection.ExecuteAsync(
                @"UPDATE [Address] SET Number = @Number, Street = @Street,
                District = @District, City = @City, State = @State, Country = @Country, 
                ZipCode = @ZipCode, UpdatedOn = @UpdatedOn WHERE CustomerId = @CustomerId",
              new
              {
                  CustomerId = customer.Id,
                  Number = customer.Address.Number,
                  Street = customer.Address.Street,
                  District = customer.Address.District,
                  City = customer.Address.City,
                  State = customer.Address.State,
                  Country = customer.Address.Country,
                  ZipCode = customer.Address.ZipCode,
                  UpdatedOn = DateTime.Now
              });

        }

        public async Task Save(Customer customer)
        {
            await _context.Connection.ExecuteAsync(
             @"INSERT INTO [Customer] VALUES (@Id, @FirstName, @LastName, @Document,
            @Email, @CreatedOn, @UpdatedOn)",
             new
             {
                 Id = customer.Id,
                 FirstName = customer.Name.FirstName,
                 LastName = customer.Name.LastName,
                 Document = customer.Document.Number,
                 Email = customer.Email.Address,
                 CreatedOn = DateTime.Now,
                 UpdatedOn = DateTime.Now,
             });

            await _context.Connection.ExecuteAsync(
            @"INSERT INTO [Address] VALUES (@Id, @CustomerId, @Number, @Street,
                @District, @City, @State, @Country, @ZipCode, @CreatedOn, @UpdatedOn)",
            new
            {
                Id = customer.Address.Id,
                CustomerId = customer.Id,
                Number = customer.Address.Number,
                Street = customer.Address.Street,
                District = customer.Address.District,
                City = customer.Address.City,
                State = customer.Address.State,
                Country = customer.Address.Country,
                ZipCode = customer.Address.ZipCode,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now
            });
        }
    }
}
