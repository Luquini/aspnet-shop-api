using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Commands.CustomerCommands;
using Shop.Domain.Commands.ProductCommands;
using Shop.Domain.Handlers;
using Shop.Domain.Queries;
using Shop.Domain.Repositories;
using Shop.Shared.Commands;

namespace Shop.Api.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _repository;
        private readonly ProductHandler _handler;

        public ProductsController(IProductRepository repository, ProductHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        [Route("v1/products")]
        public async Task<IEnumerable<ListProductQueryResult>> Get()
        {
            return await _repository.Get();
        }

        [HttpGet]
        [Route("v1/products/{id}")]
        public async Task<GetProductQueryResult> GetById(Guid id)
        {
            return await _repository.GetById(id);
        }

        [HttpPost]
        [Route("v1/products")]
        public async Task<ICommandResult> Post([FromBody] CreateProductCommand command)
        {
            var result = await _handler.Handle(command);
            return result;
        }

        [HttpPut]
        [Route("v1/products")]
        public async Task<ICommandResult> Put([FromBody] UpdateProductCommand command)
        {
            var result = await _handler.Handle(command);
            return result;
        }

        [HttpDelete]
        [Route("v1/products/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _repository.Delete(id);
            return Ok();
        }

    }
}
