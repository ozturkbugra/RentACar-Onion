using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACarApp.Application.Features.Mediator.Commands.ServiceCommands;
using RentACarApp.Application.Features.Mediator.Queries.ServiceQueries;

namespace RentACarApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ServicesList()
        {
            var value = await _mediator.Send(new GetServiceQuery());
            return Ok(value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ServicesById(int id)
        {
            var value = await _mediator.Send(new GetServiceByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateServices(CreateServiceCommand command)
        {
            await _mediator.Send(command);
            return Ok("Service eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateServices(UpdateServiceCommand command)
        {
            await _mediator.Send(command);
            return Ok("Service güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveServices(int id)
        {
            await _mediator.Send(new RemoveServiceCommand(id));
            return Ok("Service silindi");
        }
    }
}
