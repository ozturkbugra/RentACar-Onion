using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACarApp.Application.Features.Mediator.Commands.FooterAddressCommands;
using RentACarApp.Application.Features.Mediator.Queries.FooterAddressQueries;

namespace RentACarApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAddressesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FooterAddressesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> FooterAddressList()
        {
            var result = await _mediator.Send(new GetFooterAddressQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FooterAddressById(int id)
        {
            var result = await _mediator.Send(new GetFooterAddressByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFooterAddress(CreateFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Footer address eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveFooterAddress(int id)
        {
            await _mediator.Send(new RemoveFooterAddressCommand(id));
            return Ok("Footer address silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFooterAddress(UpdateFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Footer address güncellendi");
        }
    }
}
