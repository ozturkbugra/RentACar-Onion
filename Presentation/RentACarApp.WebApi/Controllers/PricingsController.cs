using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACarApp.Application.Features.Mediator.Commands.PricingCommands;
using RentACarApp.Application.Features.Mediator.Queries.PricingQueries;

namespace RentACarApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> PricingList()
        {
            var result = await _mediator.Send(new GetPricingQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPricingById(int id)
        {
            var result = await _mediator.Send(new GetPricingByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePricing(CreatePricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Pricing eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePricing(UpdatePricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Pricing güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePricing(int id)
        {
            await _mediator.Send(new RemovePricingCommand(id));
            return Ok("Pricing silindi");
        }
    }
}
