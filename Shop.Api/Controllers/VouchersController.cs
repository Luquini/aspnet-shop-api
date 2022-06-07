using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Commands.CustomerCommands;
using Shop.Domain.Commands.ProductCommands;
using Shop.Domain.Handlers;
using Shop.Domain.Queries;
using Shop.Domain.Repositories;
using Shop.Shared.Commands;

namespace Shop.Api.Controllers
{
    public class VouchersController : Controller
    {
        private readonly IVoucherRepository _repository;
        private readonly VoucherHandler _handler;

        public VouchersController(IVoucherRepository repository, VoucherHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        [Route("v1/vouchers")]
        public async Task<IEnumerable<ListVoucherQueryResult>> Get()
        {
            return await _repository.Get();
        }

        [HttpGet]
        [Route("v1/vouchers/{id}")]
        public async Task<GetVoucherQueryResult> GetById(Guid id)
        {
            return await _repository.GetById(id);
        }

        [HttpPost]
        [Route("v1/vouchers")]
        public async Task<ICommandResult> Post([FromBody] CreateVoucherCommand command)
        {
            var result = await _handler.Handle(command);
            return result;
        }

        [HttpPut]
        [Route("v1/vouchers")]
        public async Task<ICommandResult> Put([FromBody] UpdateVoucherCommand command)
        {
            var result = await _handler.Handle(command);
            return result;
        }

        [HttpDelete]
        [Route("v1/vouchers/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _repository.Delete(id);
            return Ok();
        }

    }
}
