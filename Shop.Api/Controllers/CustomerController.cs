using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using Shop.Domain.Commands;
using Shop.Domain.Commands.CustomerCommands;
using Shop.Domain.Entities;
using Shop.Domain.Handlers;
using Shop.Domain.Queries;
using Shop.Domain.Repositories;
using Shop.Shared.Commands;

namespace Shop.Api.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repository;
        private readonly CustomerHandler _handler;

        public CustomerController(ICustomerRepository repository, CustomerHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        [Route("v1/customers")]
        public async Task<IEnumerable<ListCustomerQueryResult>> Get()
        {
            return await _repository.Get();
        }

        [HttpGet]
        [Route("v1/customers/{id}")]
        public async Task<GetCustomerQueryResult> GetById(Guid id)
        {
            return await _repository.GetById(id);
        }
        /*
        [HttpGet]
        [Route("v1/customers/{id}/orders")]
        public Customer GetOrders(Guid id)
        {
            return null;
        }
        */
        [HttpPost]
        [Route("v1/customers")]
        public async Task<ICommandResult> Post([FromBody] CreateCustomerCommand command)
        {
            var result = await _handler.Handle(command);
            return result;
        }

        [HttpPut]
        [Route("v1/customers")]
        public async Task<ICommandResult> Put([FromBody] UpdateCustomerCommand command)
        {
            var result = await _handler.Handle(command);
            return result;
        }

        [HttpDelete]
        [Route("v1/customers/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _repository.Delete(id);

            return Ok();
        }

    }
}
